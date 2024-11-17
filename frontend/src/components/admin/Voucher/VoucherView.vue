<template>
    <div class=" mt-2 relative">
        <div class="flex items-center gap-2 p-2">
            <router-link :to="{name:'adminHome'}">Home:</router-link>
            <VueIcon type="mdi" :path="mdiChevronRight"/>
            <p class="text-sm">Khuyến mãi</p>
        </div>
        <div class="flex flex-col gap-5 bg-white shadow-lg mt-1 p-4">
            <div @click="open=!open" class="text-blue-500 flex self-end items-center gap-2 bg-blue-100 p-1 text-sm cursor-pointer">
                <VueIcon type="mdi" :path="mdiCogOutline" size="15"/>
                Thêm mặt hàng
            </div>
            <div v-if="open" class="grid grid-cols-1 sm:grid-cols-2 text-sm gap-4">
                <div class="flex items-center">
                    <label for="name" class="w-32">Tên voucher</label>
                    <input type="text" id="name" v-model="name" class="p-1 outline-none border-2 w-full">
                </div>
                <div class="flex items-center">
                    <label for="discountRate" class="w-32">Giảm %</label>
                    <input type="text" id="discountRate" v-model="discountRate" class="p-1 outline-none border-2 w-full">
                </div>
                <div class="flex items-center">
                    <label for="code" class="w-32">Mã</label>
                    <input type="text" id="code" v-model="code" class="p-1 outline-none border-2 w-full">
                </div>
                <div class="flex items-center">
                    <label for="startDate" class="w-32">Ngày bắt đầu</label>
                    <input type="date" id="startDate" v-model="startDate" class="p-1 outline-none border-2 w-full">
                </div>
                <div class="flex items-center">
                    <label for="endDate" class="w-32">Ngày kết thúc</label>
                    <input type="date" id="endDate" v-model="endDate" class="p-1 outline-none border-2 w-full">
                </div>
                <div @click="AddVoucher" class="p-2 w-20 text-center bg-blue-500 text-white cursor-pointer">Lưu</div>
            </div>
            <table class="w-full text-xs">
                <thead class="border">
                    <tr class="bg-gray-400 text-center">
                        <td scope="col" class="p-2 border">Id</td>
                        <td scope="col" class="p-2 border">Tên </td>
                        <td scope="col" class="p-2 border">Giảm %</td>
                        <td scope="col" class="p-2 border">Ngày bắt đầu</td>
                        <td scope="col" class="p-2 border">Ngày kết thúc</td>
                        <td scope="col" class="p-2 border">Trạng thái</td>
                        <td scope="col" class="p-2 border">Hành động</td>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(item,index) in data" :key="item.promotionId" class="">
                        <td scope="col" class="border text-center hover:text-blue-500 cursor-pointer">#{{ index }}</td>
                        <td scope="col" class="border text-center">{{ item.name }}</td>
                        <td scope="col" class="border text-center">{{ item.discountRate }}</td>
                        <td scope="col" class="border text-center">{{ getTime(item.startDate) }}</td>
                        <td scope="col" class="border text-center">{{ item.endDate?getTime(item.endDate) : 'Không có'}}</td>
                        <td scope="col" class="border text-center">{{ item.isActive ? 'hoạt động' :'không hoạt động' }}</td>
                        <td class="flex gap-2 justify-center items-center border">
                            <toggle-button :value="item.status" @change="(e) => onChange(item.promotionId, e)"></toggle-button>
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
import { mdiChevronRight,mdiCheckCircle, mdiCloseCircle,mdiCogOutline } from '@mdi/js';
import axios from 'axios';

export default {
    name:'VoucherView',
    data(){
        return{
            data:[],
            page:1,
            limit:5,
            mdiChevronRight,mdiCheckCircle,mdiCloseCircle,mdiCogOutline,
            open:false,
            name:"",
            discountRate:"",
            startDate:null,
            endDate:null,
            code:""
        }
    },
    mounted(){
        this.getVoucher()
    },
    methods:{
        onChange(promotionId, e) {
            const status = e.value; 
            console.log(status)
            this.update(promotionId, status);
        },
        getTime(date){
            return new Date(date).toLocaleDateString('en-CA');
        },
        async AddVoucher(){
            try {
                await axios.post(`/Promotion/create`,{
                    name:this.name,
                    discountRate:this.discountRate,
                    code:this.code,
                    startDate:this.getTime(this.startDate),
                    endDate:this.endDate ? this.getTime(this.endDate) : null
                })
                this.getVoucher()
                this.$toast(`Thêm thành công`, {
                    position: "top-right",
                    timeout: 5000
                });
            } catch (err) {
                console.log(err)
            }
        },
        async getVoucher(){
            try {
                const res=await axios.get(`/Promotion/GetAll`)
                this.data=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async update(promotionId, status){
            try {
                await axios.patch(`/Promotion/update/${promotionId}`,status
                , {
                        headers: {
                            'Content-Type': 'application/json' // Đảm bảo gửi đúng Content-Type
                        }
                    }
                )
                this.getVoucher()
            } catch (err) {
                console.log(err)
            }
        },
    },
}
</script>