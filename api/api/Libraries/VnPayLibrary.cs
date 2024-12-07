﻿using api.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

public class VnPayLibrary
{
    private readonly SortedList<string, string> _requestData = new SortedList<string, string>(new VnPayCompare());
    private readonly SortedList<string, string> _responseData = new SortedList<string, string>(new VnPayCompare());

    public PaymentResponseModel GetFullResponseData(IQueryCollection collection, string hashSecret)
    {
        var vnPay = new VnPayLibrary();

        foreach (var (key, value) in collection)
        {
            if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
            {
                vnPay.AddResponseData(key, value);
            }
        }

        // Kiểm tra và bảo vệ chuyển đổi dữ liệu từ chuỗi sang Int64
        long orderId = 0;
        if (!long.TryParse(vnPay.GetResponseData("vnp_TxnRef"), out orderId))
        {
            return new PaymentResponseModel()
            {
                Success = false,
                OrderId = 0,  // Trả về giá trị mặc định nếu không thể chuyển đổi
            };
        }

        long vnPayTranId = 0;
        if (!long.TryParse(vnPay.GetResponseData("vnp_TransactionNo"), out vnPayTranId))
        {
            return new PaymentResponseModel()
            {
                Success = false,
                OrderId = (int)orderId,
            };
        }

        var vnpResponseCode = vnPay.GetResponseData("vnp_ResponseCode");
        var vnpSecureHash = collection.FirstOrDefault(k => k.Key == "vnp_SecureHash").Value;
        var orderInfo = vnPay.GetResponseData("vnp_OrderInfo");

        // Kiểm tra chữ ký (signature)
        var checkSignature = vnPay.ValidateSignature(vnpSecureHash, hashSecret);
        if (!checkSignature)
        {
            return new PaymentResponseModel()
            {
                Success = false,
                OrderId = (int)orderId,
            };
        }

        if (vnpResponseCode != "00")
        {
            return new PaymentResponseModel()
            {
                Success = false,
                OrderId = (int)orderId,
            };
        }

        return new PaymentResponseModel()
        {
            Success = true,
            PaymentMethod = "VnPay",
            OrderDescription = orderInfo,
            OrderId = (int)orderId,
            PaymentId = vnPayTranId.ToString(),
            TransactionId = vnPayTranId.ToString(),
            Token = vnpSecureHash,
            VnPayResponseCode = vnpResponseCode
        };
    }

    public string GetIpAddress(HttpContext context)
    {
        try
        {
            var remoteIpAddress = context.Connection.RemoteIpAddress;

            if (remoteIpAddress == null)
                return "127.0.0.1";

            if (remoteIpAddress.AddressFamily == AddressFamily.InterNetworkV6)
            {
                remoteIpAddress = Dns.GetHostEntry(remoteIpAddress).AddressList
                    .FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            }

            return remoteIpAddress?.ToString() ?? "127.0.0.1";
        }
        catch (Exception)
        {
            return "127.0.0.1";
        }
    }

    public void AddRequestData(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _requestData.Add(key, value);
        }
    }

    public void AddResponseData(string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _responseData.Add(key, value);
        }
    }

    public string GetResponseData(string key)
    {
        return _responseData.TryGetValue(key, out var retValue) ? retValue : string.Empty;
    }

    public string CreateRequestUrl(string baseUrl, string vnpHashSecret)
    {
        var data = new StringBuilder();

        foreach (var (key, value) in _requestData.Where(kv => !string.IsNullOrEmpty(kv.Value)))
        {
            data.Append(WebUtility.UrlEncode(key) + "=" + WebUtility.UrlEncode(value) + "&");
        }

        var querystring = data.ToString();

        baseUrl += "?" + querystring;
        var signData = querystring;
        if (signData.Length > 0)
        {
            signData = signData.Remove(data.Length - 1, 1);
        }

        var vnpSecureHash = HmacSha512(vnpHashSecret, signData);
        baseUrl += "vnp_SecureHash=" + vnpSecureHash;

        return baseUrl;
    }

    public bool ValidateSignature(string inputHash, string secretKey)
    {
        var rspRaw = GetResponseData();
        var myChecksum = HmacSha512(secretKey, rspRaw);
        return myChecksum.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
    }


    private string HmacSha512(string key, string inputData)
    {
        var hash = new StringBuilder();
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var inputBytes = Encoding.UTF8.GetBytes(inputData);

        using (var hmac = new HMACSHA512(keyBytes))
        {
            var hashValue = hmac.ComputeHash(inputBytes);
            foreach (var theByte in hashValue)
            {
                hash.Append(theByte.ToString("x2"));
            }
        }

        return hash.ToString();
    }


    private string GetResponseData()
    {
        var data = new StringBuilder();
        if (_responseData.ContainsKey("vnp_SecureHashType"))
        {
            _responseData.Remove("vnp_SecureHashType");
        }

        if (_responseData.ContainsKey("vnp_SecureHash"))
        {
            _responseData.Remove("vnp_SecureHash");
        }

        foreach (var (key, value) in _responseData.Where(kv => !string.IsNullOrEmpty(kv.Value)))
        {
            data.Append(WebUtility.UrlEncode(key) + "=" + WebUtility.UrlEncode(value) + "&");
        }

        //remove last '&'
        if (data.Length > 0)
        {
            data.Remove(data.Length - 1, 1);
        }

        return data.ToString();
    }
}

public class VnPayCompare : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        if (x == y) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        var vnpCompare = CompareInfo.GetCompareInfo("en-US");
        return vnpCompare.Compare(x, y, CompareOptions.Ordinal);
    }
}
