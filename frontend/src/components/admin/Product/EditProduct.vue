<template>
    <div v-if="open" class="fixed flex items-center z-20 inset-0 bg-black bg-opacity-50 h-[100vh] w-full" >
        <div  class=" bg-white w-full mx-auto md:w-1/2">
            <div class="text-center relative">
                <h1 class="uppercase font-bold text-xl bg-[#271511] text-white p-2">Sửa sản phẩm</h1>
                <div @click="close">
                    <VueIcon type="mdi" :path="mdiClose" size="30" class="absolute top-0 right-0 hover:cursor-pointer text-white  hover:bg-red-500"/>
                </div>
            </div>
            <div class="flex flex-col gap-5 p-5">
                <input type="text" name="name" v-model="name" placeholder="Tên sản phẩm" class="border-b w-full p-2">
                <div class="flex gap-5">
                    <div>
                        <label for="Price">Giá</label>
                        <input type="number" id="Price" v-model="price" placeholder="Giá" class="border-b w-full p-2">
                    </div>
                    <div>
                        <label for="Discounted">Ưu đãi %</label>
                        <input type="number" id="Discounted" v-model="discounted" placeholder="Ưu đãi %" class="border-b w-full p-2">
                    </div>
                </div>
                <textarea placeholder="Mô tả" v-model="description" class="border-b w-full p-2"/>
                <div class="flex gap-5">
                    <select name="" id="" v-model="categoryId" class="p-2 w-40 h-10 border outline-none">
                        <option value="" selected>Danh mục</option>
                        <option v-for="item in listCategory" :key="item.categoryId" :value="item.categoryId">{{ item.name }}</option>
                    </select>
                    <div class="flex">
                        <label v-if="!image" for="file" class="w-10 h-10 md:w-20 md:h-20 border-2 flex justify-center items-center hover:cursor-pointer"><VueIcon type="mdi" :path="mdiCamera" class=""/></label>
                        <div v-else class="relative">
                            <img :src="image" alt="" class="w-10 h-10 md:w-20 md:h-20 border-2 text-2xl block hover:cursor-pointer">
                            <div @click="remove">
                                <VueIcon type="mdi" :path="mdiClose" size="20" class="absolute top-0 right-0 hover:cursor-pointer border bg-slate-100 rounded-[50%]"/>
                            </div>
                        </div>
                            <input type="file" hidden id="file" name="image" @change="handleImageChange">
                    </div>
                </div>
                <button @click="handleUpdate" class="float-end p-2 bg-blue-400 shadow-md z-10 rounded-md">Lưu</button>
            </div>
        </div>
    </div>
</template>
<script>
import {imgDb} from '../../../firebase'
import { ref, uploadBytesResumable,getDownloadURL } from 'firebase/storage'
import axios from 'axios'
import { mdiCamera, mdiClose } from '@mdi/js';
export default {
    name:"AddProduct",
    props:['open','getproduct','productIdToUpdate'],
    data(){
        return{
            percent:0,
            image:'',
            name:'',
            discounted:0,
            categoryId:'',
            price:0,
            description:'',
            listCategory:"",
            mdiClose,mdiCamera
        }
    },
    mounted(){
            this.getcategory()
            this.getProductById()
        },
    watch:{
        "productIdToUpdate":function(){
            this.getProductById()
        }
    },
    methods:{
        close(){
            this.$emit('close');
        },
        remove(){
            this.image=''
        },
        async handleImageChange(event) {
            const file = event.target.files[0];
            if (!file) return;
            try {
                const imgRef = ref(imgDb, `/product/${file.name}`);
                const uploadTask = uploadBytesResumable(imgRef, file);
                uploadTask.on(
                    "state_changed",
                    (snapshot) => {
                        this.percent = Math.round((snapshot.bytesTransferred / snapshot.totalBytes) * 100);
                    },
                    (err) => console.log(err),
                    async () => {
                        const url = await getDownloadURL(uploadTask.snapshot.ref);
                        this.image = url;
                    }
                );
            } catch (err) {
                console.error("Error uploading image:", err);
            }
        },
        async getcategory(){
            try {
                const res=await axios.get(`/Category/getAll`)
                this.listCategory=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async getProductById(){
            try {
                const res=await axios.get(`/Product/getOne/${this.productIdToUpdate}`)
                this.name=res.data.name
                this.image=res.data.image
                this.categoryId=res.data.category.categoryId
                this.description=res.data.description
                this.price=res.data.price
                this.discounted=res.data.discounted
                
            } catch (err) {
                console.log(err)
            }
        },
        async handleUpdate(){
            try {
                await axios.patch(`/Product/update/${this.productIdToUpdate}`,{
                    name:this.name,
                    categoryId:this.categoryId,
                    price:this.price,
                    description:this.description,
                    image:this.image,
                    discounted:this.discounted
                })
                this.close()
                this.getproduct()
                this.$toast(`Sửa thành công`, {
                    position: "top-right",
                    timeout: 5000
                });
            } catch (err) {
                console.log(err)
            }
        }
    }
}
</script>