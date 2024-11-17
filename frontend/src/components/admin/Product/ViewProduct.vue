<template>
    <div class="top-0 mt-2">
        <div v-if="addSize" @click="addSize=false" class="fixed flex justify-center items-center z-20 inset-0 bg-black bg-opacity-50 h-[100vh] w-full" >
            <div class="bg-white w-full mx-auto md:w-1/4 p-2 relative">
                <div @click="addSize=false" class="absolute top-0 right-0 cursor-pointer"><VueIcon type="mdi" :path="mdiClose"/></div>
                <div class="flex flex-col gap-2">
                    <div class="flex flex-col">
                        <label for="Size">Kích thước</label>
                        <select  id="Size" v-model="sizeId" class="border-b w-full p-2 outline-none">
                            <option value="">Kích thước</option>
                            <option v-for="item in sizes" :key="item.sizeId" :value="item.sizeId">{{ item.name }}</option>
                        </select>
                    </div>
                    <div>
                        <label for="Price">Giá</label>
                        <input type="number" id="Price" v-model="price" placeholder="Giá" class="border-b w-full p-2 outline-none">
                    </div>
                    <div>
                        <label for="Discounted">Ưu đãi %</label>
                        <input type="number" id="Discounted" v-model="discounted" placeholder="Ưu đãi %" class="border-b w-full p-2 outline-none">
                    </div>
                    <div @click="UpdateSize" class="bg-blue-500 text-center p-2 text-white cursor-pointer">Cập nhật</div>
                </div>
            </div>
        </div>
        <div class="flex items-center gap-2 p-2">
            <router-link :to="{name:'adminHome'}">Home:</router-link>
            <VueIcon type="mdi" :path="mdiChevronRight"/>
            <router-link :to="{name:'adminProduct'}" class="text-sm">Sản phẩm</router-link>
            <VueIcon type="mdi" :path="mdiChevronRight"/>
            <p class="text-sm">{{ product.name }}</p>
        </div>
        <div class="flex flex-col gap-5 items-center bg-white">
            <div class="flex w-full gap-2 p-2">
                <img :src="product.image" alt="" class="w-14 h-14">
                <div class="flex flex-col">
                    <p class="text-sm">{{ product.name }}</p>
                    <p class="text-sm text-gray-500">Mã mặt hàng {{ product.productId }}</p>
                </div>
            </div>
            <div class="flex gap-5 w-full px-2">
                <div id="tab1" @click="tab='tab1'" :class="tab==='tab1' ? 'border-b-2 border-blue-500 text-black':'text-gray-500'" class=" cursor-pointer py-1">Thông tin mặt hàng</div>
                <div id="tab2" @click="tab='tab2'" :class="tab==='tab2' ? 'border-b-2 border-blue-500 text-black':'text-gray-500'" class="cursor-pointer text-gray-500 py-1">Phản hồi của khách hàng</div>
            </div>
        </div>
        <div v-if="tab==='tab1'" class="flex flex-col gap-4 p-4">
            <div class="grid grid-cols-3 gap-5">
                <div class="flex flex-col items-center bg-white p-2 text-sm">
                    <star-rating v-model="listComments.averageRate "
                            :star-size="17" 
                            :show-rating="false"
                            :increment="0.1" 
                            :read-only="true" 
                            :fixed-points="1"/>                          
                            <p class="text-gray-400">({{ listComments.averageRate }})</p>
                </div>
                <div class="flex flex-col items-center bg-white p-2 ">
                    <p class="text-sm text-gray-400">Đã bán</p>
                    <p>{{ product.sell || 0 }}</p>
                </div>
                <div class="flex flex-col items-center bg-white p-2">
                    <p class="text-sm text-gray-400">Đánh giá</p>
                    <p>{{ listComments.count }}</p>
                </div>
            </div>
            <div class="bg-white p-2 flex flex-col gap-5">
                <h1 class="font-bold">Thông tin cơ bản</h1>
                <div class="flex flex-col gap-2">
                    <div class="flex ">
                        <p class="min-w-28">Giá bán</p>
                        <p>{{ product.price | numeral }} đ</p>
                    </div>
                    <div class="flex">
                        <p class="min-w-28">Màu sắc</p>
                        <div class="flex gap-2">
                            <div v-for="item in product.productColors" :key="item.productColorId" :style="{backgroundColor:item.color.code}" class="w-5 h-5 rounded-full"></div>
                            <div class="relative group w-5 h-5 flex justify-center items-center cursor-pointer border-2">+
                                <div class="hidden group-hover:flex absolute -top-5 left-5 border p-1 flex-wrap gap-3 bg-white w-40">
                                    <div v-for="item in colors" :key="item.colorId" @click="selectColor(item.colorId)" :style="{backgroundColor:item.code}" class="w-5 h-5 rounded-full"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="flex">
                        <p class="min-w-28">Kích thước</p>
                        <div class="flex gap-2">
                            <div v-for="item in product.productSizes" :key="item.productSizeId"  class="">{{ item.size.name }},</div>
                            <div @click="addSize=true" class="relative w-5 h-5 flex justify-center items-center cursor-pointer border-2">+</div>
                        </div>
                    </div>
                    <div class="flex">
                        <div class="min-w-28">Mô tả</div>
                        <div class="">{{ product.description }}</div>
                    </div>
                </div>
            </div>
        </div>
        <div v-if="tab==='tab2'" class="">
            <div class="overflow-y-auto">
                <div v-for="item in listComments.comments" :key="item.commentId" class='border-b'>
                    <div class='flex mt-3 items-center gap-3'>
                        <div class="border w-10 h-10 rounded-[50%]" >
                            <img src="/assets/image/New/new1.webp" alt="" class='rounded-[50%]'/> 
                        </div>
                        <div class=' flex flex-col'>
                            <p class="text-sm md:text-md">{{ item.user.email }}</p>
                            <div class="flex">
                                <star-rating v-model="item.rate"
                                    :star-size="17" 
                                    :show-rating="false"
                                    :increment="0.1" 
                                    :read-only="true" 
                                    :fixed-points="1"/>                              
                            </div>
                            <p class="text-[10px]">{{ item.createdDate }}</p>
                        </div>
                    </div>
                    <div class='my-2 px-2'>
                        <span class="text-xs sm:text-base">{{ item.commentText }}</span>
                        <div v-if="item.imageUrl" class="flex gap-3">
                            <img :src="item.imageUrl" class="w-10 h-10 sm:w-20 sm:h-20">
                        </div>
                    </div>
                </div>
            </div>
            <button v-if="listComments.count>10" class="w-full text-center bg-[#271511] text-white leading-8">Xem thêm bình luận (10)</button>
        </div>
    </div>
</template>
<script>
import {mdiChevronRight, mdiClose} from '@mdi/js'
import axios from 'axios';
import StarRating from 'vue-star-rating';

export default {
    name:"ViewProduct",
    components:{StarRating},
    data(){
        return{
            mdiChevronRight,mdiClose,
            productId:this.$route.query.msp,
            product:"",
            listComments:"",
            tab:"tab1",
            sizes:"",
            colors:"",
            sizeId:"",
            price:0,
            discounted:0,
            addSize:false
        }
    },
    watch:{
        "$route.query.msp":function(newValue){
            this.productId=newValue
            this.getProduct()
        }
    },
    mounted(){
        this.getProduct()
        this.getComment()
        this.getColors()
        this.getSize()

    },
    methods:{
        async selectColor(color){
            try {
                await axios.post("/ProductColor/create",{
                    productId:this.productId,
                    colorId:color
                })
                this.getProduct()
            } catch (err) {
                console.log(err)
            }
        },
        async getProduct(){
            try {
                const res=await axios.get(`/Product/getOne/${this.productId}`)
                this.product=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async getComment(){
            try {
                const res=await axios.get(`/Comment/getByProduct/${this.productId}`)
                this.listComments=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async getColors(){
            try {
                const res=await axios.get(`/Color/getAll`)
                this.colors=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async getSize(){
            try {
                const res=await axios.get(`/Size/getAll`)
                this.sizes=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async UpdateSize(){
            try {
                await axios.post("/ProductSize/create",{
                    productId:this.productId,
                    price:this.price,
                    discounted:this.discounted,
                    sizeId:this.sizeId

                })
                this.getProduct()
                this.addSize=false
            } catch (err) {
                console.log(err)
            }
        }
    }
}
</script>