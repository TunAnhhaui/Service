<template>
    <div class="flex flex-col">
        <div v-if="openVoucher"
            class="fixed flex justify-center items-center z-20 inset-0 bg-black bg-opacity-50 h-[100vh] w-[100vw]">
            <div class=" w-80 bg-white relative">
                <h1 class="p-2 border-b">Ưu đãi</h1>
                <div class="flex flex-col gap-2 p-2 max-h-[calc(23rem-8px)] overflow-y-auto">
                    <VoucherItem v-for="i in listVoucher" :key="i.promotionId" :item="i" />
                    <p v-if="listVoucher.length <= 0">Bạn không có ưu đãi nào</p>
                </div>
                <div @click="openVoucher = !openVoucher">
                    <VueIcon type="mdi" :path="mdiClose" class="absolute top-0 right-0 cursor-pointer" />
                </div>
            </div>
        </div>
        <div class="flex flex-wrap gap-2 items-center text-xs md:text-sm px-5 md:px-10 py-2 bg-gray-100 text-gray-500">
            <router-link :to="{ name: 'home' }">Trang chủ </router-link>/<p class="line-clamp-1">Thông tin giao hàng</p>
        </div>
        <div class="flex flex-col p-5 sm:p-10 dark:bg-black dark:text-white">
            <div class="grid grid-cols-1 lg:grid-cols-2 gap-5">
                <div class="flex order-2 lg:order-1 flex-col gap-2">
                    <h1>Thông tin giao hàng</h1>
                    <div class="flex flex-col border p-2 relative rounded-lg">
                        <label for="name" :class="{
                            'text-[10px] text-green-500 top-[5px]': isFocusedName || name !== '',
                            'text-sm top-[20%] translate-y-1/3': !isFocusedName && name === ''
                        }" class="absolute left-[10px] transition-all duration-300">
                            Họ và tên
                        </label>
                        <input id="name" type="text"
                            class="outline-none border-b-2 dark:bg-black dark:text-white focus:border-blue-500 p-2"
                            v-model="name" @focus="isFocusedName = true" @blur="isFocusedName = name !== ''">
                    </div>
                    <div class="flex flex-col border p-2 relative rounded-lg">
                        <label for="phone" :class="{
                            'text-[10px] text-green-500 top-[5px]': isFocusedPhone || phone !== '',
                            'text-sm top-[20%] translate-y-1/3': !isFocusedPhone && phone === ''
                        }" class="absolute left-[10px] transition-all duration-300">
                            Số điện thoại
                        </label>
                        <input id="phone" type="text"
                            class="outline-none border-b-2 dark:bg-black dark:text-white focus:border-blue-500 p-2"
                            v-model="phone" @focus="isFocusedPhone = true" @blur="isFocusedPhone = phone !== ''">
                    </div>
                    <div class="flex flex-col border p-2 relative rounded-lg">
                        <label for="address" :class="{
                            'text-[10px] text-green-500 top-[5px]': isFocusedAddress || address !== '',
                            'text-sm top-[20%] translate-y-1/3': !isFocusedAddress && address === ''
                        }" class="absolute left-[10px] transition-all duration-300">
                            Địa chỉ
                        </label>
                        <input id="address" type="text"
                            class="outline-none border-b-2 dark:bg-black dark:text-white focus:border-blue-500 p-2"
                            v-model="address" @focus="isFocusedAddress = true"
                            @blur="isFocusedAddress = address !== ''">
                    </div>
                    <div class="grid lg:grid-cols-3 gap-2">
                        <div class=" flex flex-col border p-2 relative rounded-lg">
                            <label :class="{
                                'text-[10px] text-green-500 top-[5px]': city !== '',
                                'text-sm top-[20%] translate-y-1/3 hidden': city === ''
                            }" class="absolute left-[10px] transition-all duration-300">
                                Tỉnh/ thành
                            </label>
                            <select name="" id=""
                                class="outline-none text-sm border-b-2 dark:bg-black dark:text-white focus:border-blue-500 p-2"
                                v-model="city" @change="handleCityChange" @blur="city !== ''">
                                <option selected value="">Chọn tỉnh/ thành</option>
                                <option v-for="c in cities" :key="c.Id" :value="c.Name">{{ c.Name }}</option>
                            </select>
                        </div>
                        <div class=" flex flex-col border p-2 relative rounded-lg">
                            <label :class="{
                                'text-[10px] text-green-500 top-[5px]': district !== '',
                                'text-sm top-[20%] translate-y-1/3 hidden': district === ''
                            }" class="absolute left-[10px] transition-all duration-300">
                                Quận/ huyện
                            </label>
                            <select name="" id=""
                                class="outline-none border-b-2 text-sm dark:bg-black dark:text-white focus:border-blue-500 p-2"
                                v-model="district" @change="handleDistrictChange" @blur="district !== ''">
                                <option selected value="">Chọn quận/ huyện</option>
                                <option v-for="d in districts" :key="d.Id" :value="d.Name">{{ d.Name }}</option>
                            </select>
                        </div>
                        <div class=" flex flex-col border p-2 relative rounded-lg">
                            <label :class="{
                                'text-[10px] text-green-500 top-[5px]': ward !== '',
                                'text-sm top-[20%] translate-y-1/3 hidden': ward === ''
                            }" class="absolute left-[10px] transition-all duration-300">
                                Phường/ xã
                            </label>
                            <select name="" id=""
                                class="outline-none text-sm border-b-2 dark:bg-black dark:text-white focus:border-blue-500 p-2"
                                v-model="ward" @blur="ward !== ''">
                                <option selected value="">Chọn phường/ xã</option>
                                <option v-for="w in wards" :key="w.Id" :value="w.Name">{{ w.Name }}</option>
                            </select>
                        </div>
                    </div>
                    <div class="border p-2 relative rounded-lg">
                        <label for="description" :class="{
                            'text-[10px] text-green-500 top-[5px]': isFocusedDescription || description !== '',
                            'text-sm top-[20%] translate-y-1/4': !isFocusedDescription && description == ''
                        }" class="absolute left-[10px] transition-all duration-300">
                            Viết gì đó ...
                        </label>
                        <textarea id="description"
                            class="w-full outline-none border-b-2 dark:bg-black dark:text-white focus:border-blue-500 p-2"
                            v-model="description" @focus="isFocusedDescription = true"
                            @blur="isFocusedDescription = description !== ''" />
                    </div>
                    <div class="flex flex-col gap-2">
                        <h1 class="sm:text-xl">Phương thức thanh toán</h1>
                        <div class="border flex flex-col text-xs sm:text-sm text-gray-500">
                            <div class="flex items-center gap-2 border-b p-4">
                                <input type="radio" name="payment" @change="changePayment"
                                    value="Thanh toán tiền mặt khi giao hàng (COD)" class="w-5 h-5">
                                <label for="" class="flex items-center gap-2 dark:text-white">
                                    <img src="https://hstatic.net/0/0/global/design/seller/image/payment/cod.svg?v=6"
                                        width="40" height="40" alt="">
                                    Thanh toán tiền mặt khi giao hàng (COD)</label>
                            </div>
                            <div class="flex items-center gap-2 border-b p-4">
                                <input type="radio" name="payment" @change="changePayment"
                                    value="Thanh toán online qua cổng VNPay" class="w-5 h-5">
                                <label for="" class="flex items-center gap-2 dark:text-white">
                                    <img src="https://hstatic.net/0/0/global/design/seller/image/payment/vnpay_new.svg?v=6"
                                        width="40" height="40" alt="">
                                    Thanh toán online qua cổng VNPay (ATM/Visa/MasterCard/JCB/QR Pay trên Internet
                                    Banking)</label>
                            </div>
                        </div>
                    </div>
                    <div class="flex flex-col gap-2 md:flex-row justify-between items-center">
                        <router-link :to="{ name: 'cart' }" class=" text-blue-700">Giỏ hàng</router-link>
                        <div @click="Checkout"
                            class="w-full md:w-40 text-center p-2 text-white bg-blue-700 rounded-lg cursor-pointer">Hoàn
                            tất đơn hàng</div>
                    </div>
                </div>
                <div class="order-1 lg:order-2 bg-gray-100 dark:bg-black dark:text-white border p-5">
                    <div @click="orderSumary = !orderSumary"
                        class=" flex lg:hidden justify-between cursor-pointer border-b border-black py-2">
                        <div class="text-blue-500 flex items-center gap-2">
                            <VueIcon type="mdi" :path="mdiCartOutline" />
                            <p class="text-sm">Hiển thị thông tin đơn hàng</p>
                            <VueIcon type="mdi" :path="mdiChevronDown" />
                        </div>
                        <p class="">{{ !discountPrice ? totalAmount : price | numeral }}₫</p>
                    </div>
                    <div
                        :class="{ 'hidden lg:flex flex-col gap-2 py-4 border-b border-black dark:border-white': !orderSumary, 'flex flex-col gap-2 py-4 border-b border-black': orderSumary }">
                        <div v-for="item in carts" :key="item.cartId" class="flex gap-2">
                            <div class="w-12 h-12 relative">
                                <img :src="item.product.image" alt="" class="w-12 h-12 rounded-lg border border-black">
                                <span
                                    class="absolute -top-2 -right-2 w-5 h-5 rounded-full bg-gray-500 flex justify-center items-center text-white">{{
                                        item.quantity }}</span>
                            </div>
                            <div class=" flex flex-col gap-2 text-gray-500 dark:text-white w-[70%]">
                                <p class="text-xs sm:text-sm">{{ item.product.name }}</p>
                                <div class="flex gap-5">
                                    <p class="text-xs sm:text-sm">{{ item.color }}</p>
                                    <p class="text-xs sm:text-sm">{{ item.size }}</p>
                                </div>
                            </div>
                            <p class=" text-xs sm:text-sm">{{ item.totalAmount | numeral }}₫</p>
                        </div>
                    </div>
                    <div class="flex flex-col gap-3 py-4 border-b border-black dark:border-white">
                        <div class="flex justify-between">
                            <div class="flex flex-col w-2/3 relative rounded-lg border">
                                <label :class="{
                                    'text-[10px] text-green-500 top-0 ': voucher !== '',
                                    'text-sm top-[10%] translate-y-1/3 hidden': voucher === ''
                                }" class="absolute left-[10px] transition-all duration-500">
                                    Mã giảm giá
                                </label>
                                <input type="text" placeholder="Mã giảm giá"
                                    class="outline-none dark:bg-black dark:text-white focus:border-blue-500 rounded-lg p-2"
                                    v-model="voucher" @focus="isFocusedVoucher = true"
                                    @blur="isFocusedVoucher = voucher !== ''">
                            </div>
                            <button @click="ApplyVoucher" class="text-white bg-gray-500 rounded-lg p-2 text-sm">Sử
                                dụng</button>
                        </div>
                        <div @click="openVoucher = 'true'" class="flex gap-2 w-24 cursor-pointer">
                            <VueIcon type="mdi" :path="mdiTicketPercent" class="text-blue-500" />
                            <p>Voucher</p>
                        </div>
                    </div>
                    <div :class="{ 'hidden lg:flex flex-col py-4': !orderSumary, 'flex flex-col py-4': orderSumary }">
                        <div class="flex justify-between text-gray-500 dark:text-white">
                            <p>Tạm tính</p>
                            <p>{{ totalAmount | numeral }}₫</p>
                        </div>
                        <div class="flex justify-between text-gray-500 pb- dark:text-white">
                            <p>Ưu đãi</p>
                            <p>- {{ discountPrice | numeral }}₫</p>
                        </div>
                        <div
                            class="flex justify-between text-gray-500 pt-2 border-t border-black dark:border-white dark:text-white">
                            <p class="text-black dark:text-white">Tổng cộng</p>
                            <p class="text-xl"> {{ !discountPrice ? totalAmount : price | numeral }}₫</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mdiCartOutline, mdiChevronDown, mdiClose, mdiTicketPercent } from '@mdi/js'
import VoucherItem from '@/components/voucherItem/VoucherItem.vue';
import axios from 'axios';
export default {
    name: "CheckoutView",
    props: ["carts", "totalAmount", "getCart"],
    components: { VoucherItem },
    data() {
        return {
            mdiCartOutline, mdiChevronDown, mdiTicketPercent, mdiClose,
            isFocusedName: false,
            isFocusedPhone: false,
            isFocusedAddress: false,
            isFocusedDescription: false,
            isFocusedVoucher: false,
            isFocusedCity: false,
            isFocusedDistrict: false,
            isFocusedWart: false,
            orderSumary: false,
            listVoucher: "",
            openVoucher: false,
            price: 0,
            discountPrice: 0,
            name: '',
            phone: '',
            description: '',
            paymentMethod: '',
            address: '',
            voucher: '',
            city: '',
            district: '',
            ward: '',
            cities: '',
            districts: '',
            wards: '',
            message: this.$route.query.Status,
            orderId: this.$route.query.orderId,
        }
    },
    mounted() {
        this.getVoucher()
        this.getCities()
        if (this.message == "payment-failure") {
            this.$toast.error(`Thanh toán thất bại`, {
                position: "top-right",
                timeout: 5000
            });
        }
        if (this.message == "payment-success" && this.orderId) {
            this.$toast.success(`Thanh toán thành công`, {
                position: "top-right",
                timeout: 5000
            });
            this.Update(this.orderId)
        }
    },
    methods: {
        async Update(id) {
            try {
                await axios.patch(`/Order/update/${id}`, {
                    paymentStatus: "Đã thanh toán",
                })
            } catch (err) {
                console.log(err)
            }
        },
        async getVoucher() {
            try {
                const res = await axios.get("/Promotion/getAll")
                const voucher = res.data.filter(item => item.status === true)
                this.listVoucher = voucher
            } catch (err) {
                console.log(err)
            }
        },
        ApplyVoucher() {
            const voucher = this.listVoucher.find(v => v.code === this.voucher)
            if (voucher && voucher.isActive) {
                this.discountPrice = (this.totalAmount * voucher.discountRate) / 100
                this.price = this.totalAmount - this.discountPrice
            } else {
                this.discountPrice = 0
                this.$toast.error(`Voucher không hợp lệ`, {
                    position: "top-right",
                    timeout: 5000
                });
            }
        },
        changePayment(e) {
            this.paymentMethod = e.target.value
        },
        async getCities() {
            try {
                const response = await fetch("https://raw.githubusercontent.com/kenzouno1/DiaGioiHanhChinhVN/master/data.json")
                const data = await response.json();
                this.cities = data
            } catch (err) {
                console.error(err)
            }
        },
        handleCityChange(e) {
            const selectedCityName = e.target.value;
            const selectedCity = this.cities.find(city => city.Name === selectedCityName);
            if (selectedCity) {
                this.districts = selectedCity.Districts;
            }
        },
        handleDistrictChange(e) {
            const selectedDistrictName = e.target.value;
            const selectedDistrict = this.districts.find(district => district.Name === selectedDistrictName);
            if (selectedDistrict) {
                this.wards = selectedDistrict.Wards;
            }
        },
        async HandleOrder() {
            try {
                const res = await axios.post("/Order/create", {
                    name: this.name,
                    phone: this.phone,
                    address: this.address,
                    city: this.city,
                    ward: this.ward,
                    district: this.district,
                    description: this.description,
                    discount: this.discountPrice,
                    payment: this.paymentMethod,
                    totalAmount: this.discountPrice ? this.price : this.totalAmount,
                    orderItems: this.carts.map(item => ({
                        productId: item.productId,
                        quantity: item.quantity,
                        size: item.size,
                        color: item.color,
                        totalAmount: item.totalAmount
                    }))
                })
                if (this.voucher) {
                    const voucher = this.listVoucher.find(v => v.code === this.voucher)
                    if (voucher) {
                        await axios.post("/UserPromotion/create", {
                            promotionId: voucher.promotionId
                        })
                    }
                }
                this.getCart()

                return res.data.orderId
            } catch (err) {
                console.log(err)
            }
        },
        async Checkout() {
            try {
                if (this.paymentMethod == "") {
                    this.$toast.error("Vui lòng chọn phương thức thanh toán!", {
                        position: "top-right",
                        timeout: 5000
                    });
                    return;
                }
                if (this.carts.length < 1) {
                    this.$toast.error("Bạn không có đơn hàng nào", {
                        position: "top-right",
                        timeout: 5000
                    });
                    return;
                }

                if (this.paymentMethod == "Thanh toán tiền mặt khi giao hàng (COD)") {
                    const orderId = await this.HandleOrder()
                    this.$toast.success(`Đơn hàng ${orderId} đã được đặt`, {
                        position: "top-right",
                        timeout: 5000
                    });
                    this.$router.push("/cart")
                    return;
                }
                else {
                    const orderId = await this.HandleOrder()
                    const res = await axios.post('/Payment/create-url', {
                        orderType: "Thanh toán đơn hàng",
                        amount: this.discountPrice ? this.price : this.totalAmount,
                        orderDescription: this.description,
                        name: this.name,
                        orderId: orderId
                    })
                    window.location.href = res.data;
                }

            } catch (err) {
                console.log(err)
            }
        },
    }
}
</script>

<style></style>