<template>
    <div class="w-full">
        <h1 class="text-xl font-bold">Đơn hàng của bạn<div class="border-b-4 border-yellow-500 w-14"></div></h1>
        <div class="py-2">
            <table class="w-full table border text-xs sm:text-sm">
                <thead class="bg-yellow-800">
                    <tr>
                        <th class="text-white border border-white p-2">Đơn hàng</th>
                        <th class="text-white border border-white p-2">Ngày đặt</th>
                        <th class="text-white border border-white p-2">Đơn giá</th>
                        <th class="text-white border border-white p-2">Trạng thái</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in data" :key="item.orderId" class="text-center">
                        <td class="border p-2 text-blue-500 hover:text-black"><router-link :to="{name:'orderdetail',query:{ma:item.orderId}}">#{{ item.orderId }}</router-link></td>
                        <td class="border p-2">{{ getTime(item.createDate) }}</td>
                        <td class="border p-2">{{item.totalAmount | numeral}}₫</td>
                        <td class="border p-2">{{ item.paymentStatus }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    name:"OrderView",
    data(){
        return{
            data:""
        }
    },
    mounted(){
        this.getOrder()
    },
    methods:{
        async getOrder(){
            try {
                const res=await axios.get("/Order/getByUser")
                this.data=res.data
            } catch (err) {
                console.log(err)
            }
        },
        getTime(date){
            return new Date(date).toLocaleDateString();
        }
    }
}
</script>