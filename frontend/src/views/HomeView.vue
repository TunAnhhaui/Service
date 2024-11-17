<template>
    <div  class="flex flex-col min-h-screen dark:bg-black dark:text-white">
        <div class="overflow-hidden relative flex items-center">
            <div id="slider" class="flex w-screen transition-all duration-500" :style="{ transform: `translateX(-${currentIndex * 100}%)` }">
                <img src="/assets/slider/slide1.webp" alt="" class="min-w-full h-[25vh] md:h-[50vh]">                
                <img src="/assets/slider/slide2.webp" alt="" class="min-w-full h-[25vh] md:h-[50vh]">                
                <img src="/assets/slider/slide3.webp" alt="" class="min-w-full h-[25vh] md:h-[50vh]">                
                <img src="/assets/slider/slide4.jpg" alt="" class="min-w-full h-[25vh] md:h-[50vh]">     
            </div>
            <div @click="prevSlide" class="absolute left-0 cursor-pointer animate-pulse text-black"><VueIcon type="mdi" :path="mdiChevronLeft" size="70"/></div>           
            <div @click="nextSlide" class="absolute right-0 cursor-pointer animate-pulse text-black"><VueIcon type="mdi" :path="mdiChevronRight" size="70"/></div>           
        </div>
        <div class="grid grid-cols-1 md:grid-cols-2 gap-5 py-2">
            <div class="flex flex-col items-center gap-5 p-10">
                <h1 class="uppercase text-3xl font-bold">NỘI THẤT TINH TẾ</h1>
                <p>Với kinh nghiệm hơn 24 năm trong hoàn thiện nội thất, Nhà Xinh mang đến giải pháp toàn diện trong bao gồm thiết kế, trang trí và cung cấp nội thất trọn gói. Sở hữu đội ngũ chuyên nghiệp và hệ thống 10 cửa hàng, Nhà Xinh là lựa chọn cho không gian tinh tế và hiện đại.</p>
                <a href="" class="border-2 p-2 border-green-500 text-xl font-bold hover:text-white hover:bg-green-500">Xem thêm</a>
            </div>
            <div class="">
                <img src="/assets/image/thietke.jpg" alt="w-full h-full object-cover">
            </div>
        </div>
        <div class="flex flex-col p-5 md:p-10 gap-5">
            <!-- new -->
            <div class="flex flex-col gap-2">
                <div class="flex justify-between items-center">
                    <h1 class="text-3xl font-medium">Mới nhất</h1>
                    <router-link :to="{name:'productall'}" class="text-red-500">Xem tất cả</router-link>
                </div>
                <div class="grid grid-cols-2 lg:grid-cols-4 gap-2">
                    <ProductItem v-for="item in productNew" :key="item.productId" :item="item"/>
                </div>
            </div>
            <!-- Sale -->
            <div class="flex flex-col gap-2">
                <div class="flex justify-between items-center">
                    <h1 class="text-3xl font-medium">Ưu đãi</h1>
                    <router-link :to="{name:'productall'}" class="text-red-500">Xem tất cả</router-link>
                </div>
                <div class="grid grid-cols-2 lg:grid-cols-4 gap-2">
                    <ProductItem v-for="item in productDiscount" :key="item.productId" :item="item"/>
                </div> 
            </div>
            <!-- Bán chạy -->
            <div class="flex flex-col gap-2">
                <div class="flex justify-between items-center">
                    <h1 class="text-3xl font-medium">Bán chạy</h1>
                    <router-link :to="{name:'productall'}" class="text-red-500">Xem tất cả</router-link>
                </div>
                <div class="grid grid-cols-2 lg:grid-cols-4 gap-2">
                    <ProductItem v-for="item in productDiscount" :key="item.productId" :item="item"/>
                </div> 
            </div>
            <!-- blog -->
            <div class="flex flex-col gap-2">
                <h1 class="text-3xl font-medium">Đánh giá thực tế</h1>
                <div class="flex w-full overflow-hidden relative">
                    <div id="blog" class="flex w-[calc(100vw-40px)] gap-5 md:gap-10 transition-transform duration-[3000ms] translate-x-0" :style="{ transform: `translateX(-${indexBlog * (windowWidth >= 768 ? 25 : 50)}%)` }">
                        <div v-for="(item, index) in commentView" :key="index" class="w-[calc(50%-20px)] md:w-[calc(25%-43px)] flex-shrink-0 border">
                            <div class="h-60 w-full border">
                                <img :src="item.image" alt="" class="w-full h-full object-fill">
                            </div>
                            <div class="flex flex-col gap-3 p-3">
                                <div class="flex flex-col items-center">
                                    <p>{{ item.comments[0].user.username || 'Ẩn danh' }}</p>
                                    <star-rating v-model="item.comments[0].rate"
                                        :star-size="20" 
                                        :show-rating="false"
                                        :increment="0.1" 
                                        :read-only="true" 
                                        :fixed-points="1"/> 
                                </div>
                                <p class="line-clamp-3 text-sm h-15 px-1">{{ item.comments[0].commentText }}</p>
                            </div>
                        </div>
                    </div>
                    <div @click="nextBlog" class="absolute -right-10 self-center"><VueIcon type="mdi" :path="mdiChevronRight" size="50"/></div>
                </div>

            </div>
            <!-- banner -->
             <div class="grid grid-cols-2 md:grid-cols-4 dark:bg-black dark:text-white">
                <div class="flex flex-col items-center border p-5 text-gray-500 dark:text-white">
                    <img src="https://theme.hstatic.net/200000065946/1001264503/14/vice_item_1_thumb.png?v=330" width="50" hight="50" alt="">
                    <p class="text-base md:text-xl">Giao Hàng & Lắp Đặt</p>
                    <p class="text-sm">Miễn Phí</p>
                </div>
                <div class="flex flex-col items-center border p-5 text-gray-500 dark:text-white">
                    <img src="https://theme.hstatic.net/200000065946/1001264503/14/vice_item_1_thumb.png?v=330" width="50" hight="50" alt="">
                    <p class="text-base md:text-xl">Đổi Trả 1 - 1</p>
                    <p class="text-sm">Miễn Phí</p>
                </div>
                <div class="flex flex-col items-center border p-5 text-gray-500 dark:text-white">
                    <img src="https://theme.hstatic.net/200000065946/1001264503/14/vice_item_1_thumb.png?v=330" width="50" hight="50" alt="">
                    <p class="text-base md:text-xl">Bảo Hành 2 Năm</p>
                    <p class="text-sm">Miễn Phí</p>
                </div>
                <div class="flex flex-col items-center border p-5 text-gray-500 dark:text-white">
                    <img src="https://theme.hstatic.net/200000065946/1001264503/14/vice_item_1_thumb.png?v=330" width="50" hight="50" alt="">
                    <p class="text-base md:text-xl">Tư Vấn Thiết Kế</p>
                    <p class="text-sm">Miễn Phí</p>
                </div>
             </div>
        </div>
    </div>
</template>

<script>
import {mdiChevronRight,mdiChevronLeft,mdiStar} from '@mdi/js'
import ProductItem from '@/components/productItem/ProductItem.vue';
import axios from 'axios';
import StarRating from 'vue-star-rating';

export default {
    name:"HomeView",
    components:{ProductItem,StarRating},
    data(){
        return{
            currentIndex:0,
            indexBlog:0,
            slidesCount: 4,
            mdiChevronRight,mdiChevronLeft,mdiStar,
            windowWidth: window.innerWidth,
            productNew:"",
            productDiscount:"",
            productSell:"",
            commentView:"",
        }
    },
    methods: {
        nextSlide() {
            this.currentIndex = (this.currentIndex + 1) % this.slidesCount;
        },
        prevSlide() {
            this.currentIndex = (this.currentIndex - 1 + this.slidesCount) % this.slidesCount;
        },
        startAutoSlide(){
            setInterval(()=>{
                this.nextSlide()
                this.nextBlog()
            },3000)
        },
        nextBlog(){
            if(this.windowWidth>=768 && this.indexBlog< this.commentView.length-4 && this.commentView.length>4){
                this.indexBlog++
            }
            else if(this.windowWidth<768 && this.indexBlog< this.commentView.length-2 && this.commentView.length>2){
                this.indexBlog++
            }
            else{
                this.indexBlog=0
            }
        },
        handleResize() {
            this.windowWidth = window.innerWidth; 
        },
        async getProductNew(){
            try {
                const res=await axios.get("/Product/getNew")
                this.productNew=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async getProductDiscount(){
            try {
                const res=await axios.get("/Product/getDiscount")
                this.productDiscount=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async getProductSell(){
            try {
                const res=await axios.get("/Product/getSell")
                this.productSell=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async getCommentView(){
            try {
                const res=await axios.get("/Comment/GetCommentBest")
                this.commentView=res.data
            } catch (err) {
                console.log(err)
            }
        }
    },
    mounted(){
        this.startAutoSlide()
        window.addEventListener('resize', this.handleResize); 
        this.getProductNew()
        this.getProductDiscount()
        this.getCommentView()
    },
    beforeDestroy() {
        window.removeEventListener('resize', this.handleResize); 
    }
}
</script>