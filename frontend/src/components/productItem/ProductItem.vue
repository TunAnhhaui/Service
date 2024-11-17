<template>
    <div class="flex flex-col gap-2 border">
        <div class="relative w-full">
            <router-link :to="{name:'productdetail',query:{masp: item.productId}}" class="w-full h-[40vh]"><img :src="item.image" :alt="item.name" class="w-full h-[40vh] object-contain"></router-link>
            <div v-if="item.discounted" class="absolute px-2 top-0 left-0 bg-red-500 text-white">-{{item.discounted}}%</div>
            <!-- <div class="absolute px-2 top-0 right-0 bg-orange-500 text-white">NEW</div> -->
        </div>
        <div class="px-2 dark:bg-black dark:text-white">
            <p class="uppercase text-[12px] sm:text-sm font-semibold">{{item.name}}</p>
            <p class="text-red-500 text-[12px] sm:text-base">{{item.discountedPrice ? item.discountedPrice : item.price | numeral}}<u>đ</u>&nbsp;<s v-if="item.discountedPrice" class="text-gray-400">{{item.price | numeral}}<u>đ</u></s></p>
            <div class="flex justify-between">
                <div class="flex items-center py-1">
                    <star-rating v-model="rate"
                            :star-size="15" 
                            :show-rating="false"
                            :increment="0.1" 
                            :read-only="true" 
                            :fixed-points="1"/>                          
                            ({{ item.commentCount }})
                </div>
                <p class="text-[12px] sm:text-base">Đã bán {{ item.sell }}</p>
            </div>
        </div>
    </div>
</template>

<script>
import {mdiStar, mdiHeartOutline} from '@mdi/js'
import StarRating from 'vue-star-rating';

export default {
    name:"ProductItem",
    props:["item"],
    components:{StarRating},
    data(){
        return{
            mdiStar, mdiHeartOutline,
            rate:this.item.averageRate || 0,
        }
    }
}
</script>