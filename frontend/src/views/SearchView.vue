<template>
    <div class="flex flex-col gap-5 p-5 md:p-10 dark:bg-black dark:text-white">
        <div class="flex flex-col gap-2 items-center">
            <h1 class="font-bold text-3xl">Tìm kiếm</h1>
            <p class="text-gray-600 dark:text-white">Có <b>{{ countItem }} sản phẩm</b> cho tìm kiếm</p>
            <hr class="w-32 border-2 border-black dark:border-white">
        </div>
        <div class="flex flex-col gap-2">
            <p class="self-start">Kết quả tìm kiếm cho "<b>{{ searchValue }}</b>".</p>
            <div class="grid grid-cols-2 lg:grid-cols-4 gap-2">
                <ProductItem v-for="item in listSearch" :key="item.productId" :item="item"/>
            </div>
        </div>
        <div class="flex justify-center gap-5 text-gray-500 dark:text-white items-center">
            <div class="flex justify-center gap-5 text-gray-500 dark:text-white items-center">
                <div @click="prevPage" v-if="page > 1" ><VueIcon type="mdi" :path="mdiArrowLeftThin" size="30" class="hover:text-black cursor-pointer"/></div>
                <a v-for="p in totalPages" :key="p" href="" @click.prevent="goToPage(p)" :class="{'text-black dark:text-red-500': p === page}" class="hover:text-black">{{ p }}</a>
                <div @click="nextPage" v-if="page < totalPages"><VueIcon type="mdi" :path="mdiArrowRightThin" size="30" class="hover:text-black cursor-pointer"/></div>
            </div>
        </div>
    </div>
</template>

<script>
import ProductItem from '@/components/productItem/ProductItem.vue';
import {mdiArrowLeftThin, mdiArrowRightThin} from "@mdi/js"
import axios from 'axios';
export default {
    name:"SearchView",
    components:{ProductItem},
    data(){
        return{
            mdiArrowRightThin,mdiArrowLeftThin,
            searchValue:this.$route.query.q,
            listSearch:"",
            page:1,
            limit:8,
            countItem:0,
            totalPages:0
        }
    },
    mounted(){
        this.getproduct()
    },
    watch: {
        "$route.query.q":function(newValue) {
        this.searchValue = newValue;
        this.getproduct()
        }
    },
    methods:{
        prevPage() {
        if (this.page > 1) {
            this.page--;
            this.getproduct();
        }
    },
    nextPage() {
        if (this.page < this.totalPages) {
            this.page++;
            this.getproduct();
        }
    },
    goToPage(pageNumber) {
        this.page = pageNumber;
        this.getproduct();
    },
        async getproduct(){
            try {
                const res=await axios.get(`/Product/search?q=${this.searchValue}&page=${this.page}&limit=${this.limit}`)
                this.listSearch=res.data.products
                this.countItem=res.data.total
                this.totalPages=res.data.totalPages
            } catch (err) {
                console.log(err)
            }
        },
    }
}
</script>