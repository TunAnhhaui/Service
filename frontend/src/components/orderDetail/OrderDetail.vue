<template>
    <div class="flex flex-col gap-5">
        <div class="flex flex-col lg:flex-row justify-between gap-5">
            <h1 class="text-xl font-bold">Chi tiết đơn hàng  #{{ orderId }}<div class="border-b-4 border-yellow-500 w-14"></div></h1>
            <p class="text-sm">Ngày tạo: {{ getTime(data.createDate) }}</p>
        </div>
        <div class="flex flex-col lg:flex-row text-sm gap-5">
            <p>Trạng thái thanh toán:<em class="font-bold text-red-500">{{ data.paymentStatus }}</em></p>
            <p>Trạng thái vận chuyển: <em class="font-bold">{{ data.shippingStatus }}</em></p>
        </div>
        <div class="lg:grid grid-cols-12 gap-5">
            <div class="col-span-6">
                <h1 class="text-xl">Địa chỉ giao hàng</h1>
                <div class="border py-2 px-4 text-sm min-h-24 rounded-md">
                    <strong class="uppercase">{{ data.name }}</strong>
                    <p>Địa chỉ: {{ data.address }}</p>
                    <p>Tỉnh/ Thành phố: {{ data.city }}</p>
                    <p>Quận/ huyện: {{ data.district }}</p>
                    <p>Phường/ Xã: {{ data.ward }}</p>
                </div>
            </div>
            <div class="col-span-3">
                <h1 class="text-xl">Thanh toán</h1>
                <div class="border py-2 px-4 text-sm min-h-24 rounded-md">
                    <p>{{ data.payment }}</p>
                </div>
            </div>
            <div class="col-span-3">
                <h1 class="text-xl">Ghi chú</h1>
                <div class="border py-2 px-4 text-sm min-h-24 rounded-md">
                    <p>{{ data.description }}</p>
                </div>
            </div>
        </div>
        <div class="border p-2 flex flex-col gap-3">
            <table class="table w-full">
                <thead class="hidden lg:table-header-group">
                    <tr class="border-b">
                        <td class="p-2">Sản phẩm</td>
                        <td class="p-2">Số lượng</td>
                        <td class="p-2">Tổng</td>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in data.orderItems" :key="item.orderItemId" class="border-b text-sm sm:text-base">
                        <td class="p-2 flex items-center gap-5">
                            <img :src="item.product.image" alt="" class="w-10 h-10 object-cover">
                            <div class="flex flex-col">
                                <span>{{ item.product.name }}</span>
                                <span class="lg:hidden">x{{ item.quantity }}</span>
                            </div>
                        </td>
                        <td class="p-2 hidden lg:table-cell">{{ item.quantity }}</td>
                        <td class="p-2 ">{{item.totalAmount | numeral}}₫</td>
                    </tr>
                </tbody>
            </table>
            <table class="flex justify-end text-sm sm:text-base">
                <tfoot>
                    <tr>
                        <td class="w-2/4">Khuyến mại</td>
                        <td>{{data.discount | numeral}}₫</td>
                    </tr>
                    <tr>
                        <td class="w-2/4">Tổng tiền</td>
                        <td class="font-bold text-red-500">{{data.totalAmount | numeral}}₫</td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default{
    name:"OrderDetail",
    data(){
        return{
            data:"",
            orderId:this.$route.query.ma
        }
    },
    mounted(){
        this.getOrder()
    },
    watch:{
        "$route.query.ma":function(newValue){
            this.orderId=newValue
            this.getOrder()
        }
    },
    methods:{
        async getOrder(){
            try {
                const res=await axios.get(`/Order/GetById/${this.orderId}`)
                this.data=res.data
                console.log(this.data)
            } catch (err) {
                console.log(err)
            }
        },
        getTime(date){
            return new Date(date).toLocaleDateString();
        },
    }
}
</script>