<template>
    <div class="flex flex-col ">
        <div class="flex flex-wrap gap-2 items-center text-xs md:text-sm px-5 md:px-10 py-2 bg-gray-100 text-gray-500">
            <router-link :to="{name:'home'}">Trang chủ </router-link>/<p>Danh mục</p>/<p class="line-clamp-1">Tất cả sản phẩm</p>
        </div>
        <img src="\assets\image\all.webp" alt="" class="min-w-full h-[25vh] md:h-[60vh]">
        <div class="flex flex-col gap-5 p-5 md:p-10 dark:bg-black dark:text-white">
            <h1 class="font-bold text-base sm:text-xl md:text-3xl">Tất cả sản phẩm</h1>
            <div class="grid sm:grid-cols-2 lg:grid-cols-4 items-center gap-10 text-sm sm::text-base">
                <select name="sort" id="" v-model="sort" class="border-b dark:bg-black dark:text-white outline-none p-2">
                    <option value="">Sản phẩm nổi bật</option>
                    <option value="price_asc">Giá: Tăng dần</option>
                    <option value="price_desc">Giá: Giảm dần</option>
                    <option value="new">Mới nhất</option>
                    <option value="">Bán chạy nhất</option>
                </select>
                <div class="flex gap-2 w-full">
                    <select name="min" id="" v-model="min" class="border-b w-full dark:bg-black dark:text-white outline-none p-2">
                        <option value="">Tối thiểu</option>
                        <option value="0">0</option>
                        <option value="1000000">1,000,000₫</option>
                        <option value="5000000">5,000,000₫</option>
                        <option value="10000000">10,000,000₫</option>
                        <option value="20000000">20,000,000₫</option>
                    </select>
                    <select name="max" id="" v-model="max" class="border-b w-full dark:bg-black dark:text-white outline-none p-2">
                        <option value="">Tối đa</option>
                        <option value="1000000">1,000,000₫</option>
                        <option value="5000000">5,000,000₫</option>
                        <option value="10000000">10,000,000₫</option>
                        <option value="20000000">20,000,000₫</option>
                        <option value="50000000">50,000,000₫</option>
                    </select>
                </div>
                <div class="flex items-center justify-between  border-b p-2  relative group">
                    <p>Màu sắc: {{ selectColor }}</p>
                    <VueIcon type="mdi" :path="mdiChevronDown"/>
                    <div class="absolute dark:bg-black -z-10 opacity-0 ease-in-out duration-700 translate-y-40 transform group-hover:z-10 group-hover:translate-y-10 group-hover:opacity-100 top-0 border w-full left-0 p-2 text-sm text-gray-500 bg-white">
                        <div class="flex gap-3 flex-wrap">
                            <li v-for="color in colors" :key="color.colorId" class="list-none">
                                <label @click="selectedColor(color.name)" :style="{ backgroundColor: color.code }" :class="selectColor === color.name ? 'border-2 border-gray-700' :''" class="w-6 h-6 rounded-full inline-block cursor-pointer"></label>
                            </li>
                        </div>
                    </div>
                </div>
                <div class="flex items-center justify-between  border-b p-2  relative group">
                    <p>Kích thước:{{ selectSize }}</p>
                    <VueIcon type="mdi" :path="mdiChevronDown"/>
                    <ul class="absolute dark:bg-black dark:text-white -z-10 opacity-0 ease-in-out duration-700 translate-y-40 transform group-hover:z-10 group-hover:translate-y-10 group-hover:opacity-100 top-0 border w-full left-0 p-2 text-sm text-gray-500 bg-white">
                        <div class="flex flex-wrap gap-2 p-2">
                            <div v-for="item in sizes" :key="item.sizeId" @click="selectedSize(item.name)"  :class="selectSize===item.name && 'border-2 bg-gray-200'" class="p-2 border cursor-pointer">{{ item.name }}</div>
                            
                        </div>
                    </ul>
                </div>
            </div>
            <div class="flex gap-5">
                <div class="flex gap-2 flex-wrap ">
                    <div v-if="selectSize" class="flex px-1 items-center gap-1 w-auto text-sm border text-gray-500 dark:text-white rounded-md">Kích thước: <b>{{ selectSize }}</b>
                        <div @click="deleteSize"><VueIcon type="mdi" :path="mdiClose" class="cursor-pointer"/></div>
                    </div>  
                    <div v-if="selectColor" class="flex px-1 items-center gap-1 w-auto text-sm border text-gray-500 dark:text-white rounded-md">Màu sắc: <b>{{ selectColor }}</b>
                        <div @click="deleteColor"><VueIcon type="mdi" :path="mdiClose" class="cursor-pointer"/></div>
                    </div>
                    <div v-if="min" class="flex px-1 items-center gap-1 w-auto text-sm border text-gray-500 dark:text-white rounded-md">Giá tối thiểu: <b>{{ min }}</b>
                        <div @click="deleteMin"><VueIcon type="mdi" :path="mdiClose" class="cursor-pointer"/></div>
                    </div>  
                    <div v-if="max" class="flex px-1 items-center gap-1 w-auto text-sm border text-gray-500 dark:text-white rounded-md">Giá tối đa: <b>{{ max }}</b>
                        <div @click="deleteMax"><VueIcon type="mdi" :path="mdiClose" class="cursor-pointer"/></div>
                    </div>
                    <div v-if="sort" class="flex px-1 items-center gap-1 w-auto text-sm border text-gray-500 dark:text-white rounded-md">Sắp xếp: <b>{{ sort }}</b>
                        <div @click="deleteSort"><VueIcon type="mdi" :path="mdiClose" class="cursor-pointer"/></div>
                    </div>
                </div>
            </div>
            <div @click="handleFilter" class="sm:w-40 text-center p-2 uppercase text-white bg-black dark:bg-white dark:text-black cursor-pointer">Áp dụng</div>
            <div>
                <div class="grid grid-cols-2 lg:grid-cols-4 gap-2">
                    <ProductItem v-for="item in products" :key="item.productId" :item="item"/>
                </div>
                <div class="flex justify-center gap-5 text-gray-500 dark:text-white items-center">
                    <div @click="prevPage" v-if="page > 1" ><VueIcon type="mdi" :path="mdiArrowLeftThin" size="30" class="hover:text-black cursor-pointer"/></div>
                    <a v-for="p in totalPages" :key="p" href="" @click.prevent="goToPage(p)" :class="{'text-black dark:text-red-500': p === page}" class="hover:text-black">{{ p }}</a>
                    <div @click="nextPage" v-if="page < totalPages"><VueIcon type="mdi" :path="mdiArrowRightThin" size="30" class="hover:text-black cursor-pointer"/></div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {mdiChevronDown, mdiClose, mdiFilterOutline,mdiArrowRightThin,mdiArrowLeftThin} from "@mdi/js"
import ProductItem from "@/components/productItem/ProductItem.vue";
import axios from "axios";
export default {
    name:"ProductAll",
    components:{ProductItem},
    data(){
        return{
            colors:"",
            sizes:"",
            mdiFilterOutline,mdiChevronDown,mdiClose,mdiArrowRightThin,mdiArrowLeftThin,
            selectColor:"",
            selectSize:"",
            sort:"",
            min:"",
            max:"",
            products:"",
            page:1,
            limit:12,
            totalPages:0,
        }
    },
    mounted(){
        this.getProducts()
        this.getColors()
        this.getSizes()
    },
    methods:{
        selectedColor(color){
            this.selectColor=color
        },
        selectedSize(size){
            this.selectSize=size
        },
        deleteSize(){
            this.selectSize=""
        },
        deleteColor(){
            this.selectColor=""
        },
        deleteMax(){
            this.max=""
        },
        deleteMin(){
            this.min=""
        },
        deleteSort(){
            this.sort=""
        },
        handleFilter(){
            this.getProducts()
        },
        async getProducts(){
            try {
                const res=await axios.get(`/Product/getByPage?page=${this.page}&limit=${this.limit}&sort=${this.sort}&minPrice=${this.min}&maxPrice=${this.max}&size=${this.selectSize}&color=${this.selectColor}`)
                this.products=res.data.products
                this.totalPages = res.data.totalPages;
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
        async getSizes(){
            try {
                const res=await axios.get(`/Size/getAll`)
                this.sizes=res.data
            } catch (err) {
                console.log(err)
            }
        },
        prevPage() {
        if (this.page > 1) {
            this.page--;
            this.getProducts();
        }
    },
    nextPage() {
        if (this.page < this.totalPages) {
            this.page++;
            this.getProducts();
        }
    },
    goToPage(pageNumber) {
        this.page = pageNumber;
        this.getProducts();
    }
    }

}
</script>