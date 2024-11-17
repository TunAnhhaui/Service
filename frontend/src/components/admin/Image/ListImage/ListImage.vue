<template>
    <div class="p-5">
        <div class="flex justify-between gap-2 p-4">
            <div class="flex items-center gap-2 p-2">
                <router-link :to="{name:'adminHome'}">Home:</router-link>
                <VueIcon type="mdi" :path="mdiChevronRight"/>
                <router-link :to="{name:'imageCollection'}" class="text-sm">Ảnh</router-link>
                <VueIcon type="mdi" :path="mdiChevronRight"/>
                <p class="text-sm">{{productName}}</p>
            </div>            
            <label for="file" class="text-blue-500 flex items-center gap-2 bg-blue-100 p-1 text-sm cursor-pointer">
                <VueIcon type="mdi" :path="mdiCogOutline" size="15"/>
                Tải ảnh lên
            </label>            
            <input type="file" hidden id="file" name="image" @change="handleImageChange">
        </div>
        <div class="grid grid-cols-12 gap-2 p-5 bg-white">
            <div v-for="item in listImages" :key="item.productImageId" class="col-span-4 sm:col-span-3 md:col-span-2 border-2">
                <div class="relative" v-viewer>
                    <img :src="item.imageUrl" alt="" class="w-full h-full">
                    <div @click="Delete(item.productImageId)" class="absolute top-0 right-0 cursor-pointer border-b rounded-full bg-gray-300"><VueIcon type="mdi" :path="mdiClose" size="20" /></div>
                </div>
                <viewer :src="item.imageUrl">
                    <img :src="src">
                </viewer>
            </div>
        </div>
    </div>
</template>
<script>
import {mdiClose, mdiKeyboardBackspace,mdiCogOutline,mdiChevronRight} from "@mdi/js"
import {imgDb} from '../../../../firebase'
import { ref, uploadBytesResumable,getDownloadURL } from 'firebase/storage'
import axios from "axios";
export default {
    name:"ListImage",
    data(){
        return{
            mdiKeyboardBackspace,mdiClose,mdiCogOutline,mdiChevronRight,
            productId:this.$route.params.id,
            image:"",
            listImages:"",
            productName:this.$route.query.img,
            percent:0
        }
    },
    watch:{
        "$route.params.id":function(newValue){
            this.productId=newValue
        },
        "$route.query.img":function(newValue){
            this.productName=newValue
        }
    },
    mounted(){
        this.getImage()
    },
    methods:{
        async handleImageChange(event) {
            const file = event.target.files[0];
            if (!file) return;
            try {
                const imgRef = ref(imgDb, `/product/${this.productId}/${file.name}`);
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
                        if(this.image){
                            try {
                                await axios.post("/ProductImage/create",{
                                    imageUrl:this.image,
                                    productId:this.productId
                                })
                                this.getImage()
                                this.$toast(`Upload thành công`, {
                                    position: "top-right",
                                    timeout: 5000
                                });
                            } catch (err) {
                                console.log(err)
                            }
                        }
                    }
                );
            } catch (err) {
                console.error("Error uploading image:", err);
            }
        },
        async getImage(){
            try {
                const res=await axios.get(`/ProductImage/getByProduct/${this.productId}`)
                this.listImages=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async Delete(id){
            try {
                await axios.delete(`/ProductImage/delete/${id}`)
                this.getImage()
            } catch (err) {
                console.log(err)
            }
        }
    }
}
</script>