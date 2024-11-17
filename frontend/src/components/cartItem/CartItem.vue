<template>
    <tr class="text-sm lg:text-base w-full">
            <td class="flex items-center gap-3 p-3 max-w-[70vh]">
                <img :src="item.product.image" alt="" class="w-12 h-12 sm:w-16 sm:h-16 object-cover">
                <div class="text-xs md:text-sm">
                    <router-link :to="{name:'productdetail',params:{id:item.productId}}"><p class=" font-bold text-gray-600 dark:text-white">{{ item.product.name }}</p></router-link>
                    <div class="flex gap-5 text-xs">
                        <p class="">{{ item.color }}</p>
                        <p class="">{{ item.size }}</p>
                    </div>
                    <p @click="deleteCart(item.cartId)" class="text-yellow-500 cursor-pointer hidden lg:block">Xóa</p>
                    <div class="flex lg:hidden ">
                        <button @click="discount(item.cartId)" class="w-6 h-6 border dark:bg-white dark:text-black">-</button>
                        <input type="text" class="w-6 h-6 border text-center dark:bg-white dark:text-black" v-model="quantity">
                        <button @click="increase(item.cartId)" class="w-6 h-6 border dark:bg-white dark:text-black">+</button>   
                    </div>
                </div>
            </td>
            <td class="text-xs md:text-sm text-red-500 font-bold p-2">
                {{ price | numeral}} <u>đ</u>
                <p @click="deleteCart(item.cartId)" class="text-yellow-500 cursor-pointer lg:hidden">Xóa</p>
            </td>
            <td class="p-2 hidden lg:table-cell">
                <button @click="discount(item.cartId)" class="w-6 h-6 border dark:bg-white dark:text-black">-</button>
                <input type="text" class="w-6 h-6 border text-center dark:bg-white dark:text-black" v-model="quantity">
                <button @click="increase(item.cartId)" class="w-6 h-6 border dark:bg-white dark:text-black">+</button>   
            </td>
            <td class="text-red-500 font-bold p-2 hidden lg:table-cell">{{ item.totalAmount | numeral}} <u>đ</u></td>
        </tr>
</template>

<script>
import axios from 'axios';

export default {
    name:"CartItem",
    props:["item","getCart"],
    data(){
        return{
            price:0,
            quantity:this.item.quantity
        }
    },
    mounted(){
        this.getPrice()
    },
    methods:{
        getPrice(){
            const selectedProductSize = this.item.product.productSizes?.find(ps => ps.size.name === this.item.size);
            if (selectedProductSize) {
                this.price =selectedProductSize.discountedPrice ?? selectedProductSize.price;
            }else{
                this.price=this.item.product.discountedPrice ?? this.item.product.price;
            }
        },
        async deleteCart(id){
            try {
                await axios.delete(`/Cart/delete/${id}`)
                this.$toast(`Xóa thành công`, {
                    position: "top-right",
                    timeout: 5000
                });
                this.getCart()
            } catch (err) {
                console.log(err)
            }
        },
        async increase(id){
            if(this.quantity<10){
                this.quantity++
            }
            try {
                await axios.patch(`/Cart/update/${id}`,{
                    quantity:this.quantity,
                    totalAmount:this.price * this.quantity
                })
                this.getCart()
            } catch (err) {
                console.log(err)
            }
        },
        async discount(id){
            if(this.quantity>1){
                this.quantity--
            }
            try {
                await axios.patch(`/Cart/update/${id}`,{
                    quantity:this.quantity,
                    totalAmount:this.price * this.quantity
                })
                this.getCart()
            } catch (err) {
                console.log(err)
            }
        },

    }
}
</script>