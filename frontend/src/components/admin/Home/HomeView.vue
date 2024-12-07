<template>
    <div class="flex flex-col gap-4">
        <div class="grid grid-cols-2 md:grid-cols-4 gap-5">
            <div class="flex flex-col justify-center text-sm bg-white p-2 shadow-2xl h-24 rounded-lg">
                <div class="flex justify-between items-center">
                    <p>Tổng sản phẩm</p>
                    <VueIcon type="mdi" :path="mdiPackageVariantClosed" size="30" class="text-orange-500"/>
                </div>
                <p class="text-orange-500">{{ productCount }} </p>
            </div>
            <div class="flex flex-col justify-center text-sm bg-white p-2 shadow-2xl h-24 rounded-lg">
                <div class="flex justify-between items-center">
                    <p>Tổng khách hàng</p>
                    <VueIcon type="mdi" :path="mdiAccount" size="30" class="text-green-500"/>
                </div>
                <p class="text-green-500">{{ userCount }}</p>
            </div>
            <div class="flex flex-col justify-center text-sm bg-white p-2 shadow-2xl h-24 rounded-lg">
                <div class="flex justify-between items-center">
                    <p>Tổng đơn hàng</p>
                    <VueIcon type="mdi" :path="mdiShoppingOutline" size="30" class="text-red-500"/>
                </div>
                <p class="text-red-500">{{ orderCount }}</p>
            </div>
            <div class="flex flex-col justify-center text-sm bg-white p-2 shadow-2xl h-24 rounded-lg">
                <div class="flex justify-between items-center">
                    <p>Tổng tiền đơn hàng</p>
                    <VueIcon type="mdi" :path="mdiCash" size="30" class="text-blue-500"/>
                </div>
                <p class="text-blue-500">{{ totalAmount |numeral }} VND</p>
            </div>
        </div>
        <div class="flex flex-col gap-2 border p-4 bg-white">
            <div class="flex justify-between">
                <select v-model="selectedYear" class="w-24 border outline-none">
                    <option v-for="item in year" :key="item.year" :value="item.year">{{item.year}}</option>
                </select>
                <div class="flex cursor-pointer bg-green-500 p-2 border rounded" @click="handleExport"><VueIcon type="mdi" :path="mdiFileExcel" class="text-white"/><b>Xuất Excel</b></div>
            </div>
            <LineChart :categories="categories" :revenueByMonth="revenueByMonth"/>
            <BarChart/>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import LineChart from '../../splinechart/SplineChart.vue'
import { mdiCash,mdiAccount,mdiShoppingOutline,mdiPackageVariantClosed,mdiFileExcel } from '@mdi/js';
import BarChart from '@/components/barchart/BarChart.vue';

export default {
    name:"HomeView",
    components:{LineChart,BarChart},
    data(){
        return{
            year:"",
            selectedYear:new Date().getFullYear(),
            categories:[],
            revenueByMonth:[],
            totalAmount:0,
            productCount:0,
            orderCount:0,
            userCount:0,
            mdiCash,mdiAccount,mdiShoppingOutline,mdiPackageVariantClosed,mdiFileExcel
        }
    },
    watch:{
        "selectedYear":function(newValue){
            if(newValue){
                this.getTotalByMonth()
            }
        }
    },
    methods:{
        async handleExport(){
            try {
                const res=await axios.get(`/Order/Export?year=${this.selectedYear}`,{
                    responseType: 'blob',
                })
                const blob = new Blob([res.data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
                const url = window.URL.createObjectURL(blob);
                const a = document.createElement('a');
                a.href = url;
                a.download = `DoanhThu_${this.selectedYear}.xlsx`; // Tên file tải về
                a.style.display = 'none'; // Ẩn thẻ <a>
                document.body.appendChild(a);
                a.click(); // Tự động kích hoạt click
                document.body.removeChild(a); // Xóa thẻ <a> sau khi tải xong
                window.URL.revokeObjectURL(url); // Giải phóng URL sau khi dùng
            } catch (err) {
                console.log(err)
            }
        },
        async getTotalByMonth(){
            try {
                const res=await axios.get(`/Order/Statistical?year=${this.selectedYear}`)
                const data = res.data.monthlyStatistics;
                this.totalAmount=res.data.totalAmountAllYears
                this.year=res.data.yearlyStatistics
                this.categories = Array.from({ length: 12 }, (v, i) => `${i + 1}`);
                const revenueByMonth = new Array(12).fill(0);
                data.map(item=> {
                    if (item.month && item.totalAmount) {
                        revenueByMonth[item.month - 1] = (item.totalAmount / 1000000).toFixed(2);
                    }
                });
                this.revenueByMonth = revenueByMonth;
            } catch (err) {
                console.log(err)
            }
        },
        async getOrder(){
            try {
                const res=await axios.get("/Order/getAll")
                const data=res.data?.map(o=>o.paymentStatus=="Đã thanh toán")
                this.orderCount=data.length
            } catch (err) {
                console.log(err)
            }
        },
        async getUser(){
            try {
                const res=await axios.get("/User/getByPage")
                this.userCount=res.data.length
            } catch (err) {
                console.log(err)
            }
        },
        async getProduct(){
            try {
                const res=await axios.get("/Product/getAll")
                this.productCount=res.data.length
            } catch (err) {
                console.log(err)
            }
        },
    },
    mounted(){
        this.getTotalByMonth()  
        this.getOrder()
        this.getUser()
        this.getProduct()
    }
}
</script>