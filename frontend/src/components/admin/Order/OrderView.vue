<template>
    <div class=" mt-2 relative">
        <div class="flex items-center gap-2 p-2">
            <router-link :to="{name:'adminHome'}">Home:</router-link>
            <VueIcon type="mdi" :path="mdiChevronRight"/>
            <p class="text-sm">Đơn hàng</p>
        </div>
        <div class="bg-white shadow-lg mt-1">
            <table class="w-full text-xs">
                <thead class="border">
                    <tr class="bg-gray-400 text-center">
                        <td scope="col" class="p-2 border">Đơn hàng</td>
                        <td scope="col" class="p-2 border">Ngày</td>
                        <td scope="col" class="p-2 border">Đơn giá</td>
                        <td scope="col" class="p-2 border">Thanh toán</td>
                        <td scope="col" class="p-2 border">Vận chuyển</td>
                        <td scope="col" class="p-2 border">Hành động</td>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in data" :key="item.orderId" class="">
                        <td scope="col" @click="toggleDetails(item.orderId)" class="border text-center hover:text-blue-500 cursor-pointer">#{{ item.orderId }}</td>
                        <td scope="col" class="border text-center">{{ formatDate(item.createDate) }}</td>
                        <td scope="col" class="border text-center">{{ item.totalAmount | numeral }} đ</td>
                        <td scope="col" class="border text-center">{{ item.paymentStatus }}</td>
                        <td scope="col" class="border text-center">{{ item.shippingStatus }}</td>
                        <td class="flex gap-2 justify-center items-center border">
                            <div @click="Update(item.orderId,item.paymentStatus,item.shippingStatus)" :class="item.shippingStatus==='Đã giao' ? 'text-blue-500':'text-red-500'" class=" cursor-pointer"><VueIcon type="mdi" :path="mdiCheckCircle"/></div>
                            <div class="text-red-500"><VueIcon type="mdi" :path="mdiCloseCircle"/></div>
                        </td>
                    </tr>
                    <tr v-if="selectedOrderId === orderDetail.orderId">
                        <td colspan="6" class="p-4">
                            <div class="bg-gray-100 p-2">
                                <!-- Hiển thị thông tin chi tiết ở đây -->
                                <p><strong>Chi tiết đơn hàng #{{ orderDetail.orderId }}</strong></p>
                                <p>Khách hàng: {{ orderDetail.user.username }}</p>
                                <p>Địa chỉ: {{ orderDetail.address }}</p>
                                <p>Số điện thoại: {{ orderDetail.phone }}</p>
                                <!-- Thêm thông tin chi tiết khác -->
                            </div>
                        </td>
                    </tr>  
                </tbody>
            </table>
        </div>
        <!-- <div class="absolute bottom-0 right-0">
            <div class="flex gap-2">
                <font-awesome-icon icon="arrow-left" v-if="page>1" @click="prevPage" class="p-2 bg-blue-400 hover:cursor-pointer"/>
                <font-awesome-icon icon="arrow-right" @click="nextPage" class="p-2 bg-blue-400 hover:cursor-pointer"/>
            </div>
        </div> -->
    </div>
</template>
<script>
import { mdiChevronRight,mdiCheckCircle, mdiCloseCircle } from '@mdi/js';
import axios from 'axios';
import moment from 'moment';

export default {
    name:'OrderView',
    props:['updateTotal'],
    data(){
        return{
            data:[],
            page:1,
            limit:20,
            mdiChevronRight,mdiCheckCircle,mdiCloseCircle,
            selectedOrderId:null,
            orderDetail:""
        }
    },
    mounted(){
        this.getOrder()
    },
    methods:{
        formatDate(date) {
            return moment(date).format('YYYY-MM-DD');
        },
        toggleDetails(orderId) {
            this.selectedOrderId = this.selectedOrderId === orderId ? null : orderId;
            this.getOrderDetail()
        },
        async getOrder(){
            try {
                const res=await axios.get(`/Order/GetAll?page=${this.page}&limit=${this.limit}`)
                this.data=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async getOrderDetail(){
            try {
                const res=await axios.get(`/Order/GetById/${this.selectedOrderId}`)
                this.orderDetail=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async Update(id,paymentStatus,shippingStatus){
            try {
                let newStatusPayment;
                let newStatusShipping;
                if(paymentStatus==="Chưa thanh toán"){
                    newStatusPayment="Đã thanh toán"
                }else{
                    newStatusPayment="Đã thanh toán"
                }
                if(shippingStatus==="Chưa chuyển"){
                    newStatusShipping="Đã giao"
                }else{
                    newStatusShipping="Đã giao"
                }
                await axios.patch(`/Order/update/${id}`,{
                    paymentStatus:newStatusPayment,
                    shippingStatus:newStatusShipping

                })
                this.getOrder()
            } catch (err) {
                console.log(err)
            }
        }
    },
}
</script>