<template>
    <div>
        <h1 class="text-xl font-bold">Thông tin tài khoản<div class="border-b-4 border-yellow-500 w-14"></div></h1>
        <div class="py-2 flex flex-col md:grid grid-cols-3 gap-4">
            <div class="col-span-2 order-2 md:order-1 flex flex-col gap-4">
                <div class="flex  items-center gap-2">
                    <label for="username"  class="w-1/3 text-sm text-gray-500  dark:text-white">Tên đăng nhập</label>
                    <input type="text" v-model="username" id="username" class="w-full outline-none border dark:bg-black dark:text-white p-2">
                </div>
                <div class="flex  items-center gap-2">
                    <label for="phone" class="w-1/3 text-sm text-gray-500 dark:bg-black dark:text-white">Số điện thoại</label>
                    <input type="text" v-model="phone" id="phone" class="w-full outline-none dark:bg-black dark:text-white border p-2">
                </div>
                <div class="flex items-center gap-2">
                    <label for="email" class="w-1/3 text-sm text-gray-500 dark:bg-black dark:text-white">Email</label>
                    <input type="text" v-model="email" id="email" class="w-full outline-none dark:bg-black dark:text-white border p-2">
                </div>
                <div class="flex items-center gap-2">
                    <label for="address" class="w-1/3 text-sm text-gray-500 dark:bg-black dark:text-white">Địa chỉ</label>
                    <textarea id="address" v-model="address" class="w-full outline-none dark:bg-black dark:text-white border p-2"></textarea>
                </div>
                <div @click="Update" class="p-2 w-20 text-center bg-red-500 text-white cursor-pointer">Lưu</div>
            </div>
            <div class="col-span-1 order-1 md:order-2 border-l flex flex-col gap-2 items-center">
                <img :src="imageUrl ? imageUrl : 'data:image/jpeg;base64,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'" alt="" class="w-32 h-32 rounded-full"/>
                <label for="file" class="p-2 border-2 cursor-pointer">Chọn ảnh</label>
                <input type="file" name="" id="file" hidden @change="handleImageChange">
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import {imgDb} from '../../firebase'
import { ref, uploadBytesResumable,getDownloadURL } from 'firebase/storage'
// import axios from 'axios'
export default{
    name:"AccountView",
    data(){
        return{
            username:this.$store.state.user.username,
            email:this.$store.state.user.email,
            phone:this.$store.state.user.phone,
            address:this.$store.state.user.address,
            imageUrl:this.$store.state.user.imageUrl,
            percent:0
        }
    },
    methods:{
        async handleImageChange(event) {
            const file = event.target.files[0];
            if (!file) return;
            try {
                const imgRef = ref(imgDb, `/account/${file.name}`);
                const uploadTask = uploadBytesResumable(imgRef, file);
                uploadTask.on(
                    "state_changed",
                    (snapshot) => {
                        this.percent = Math.round((snapshot.bytesTransferred / snapshot.totalBytes) * 100);
                    },
                    (err) => console.log(err),
                    async () => {
                        const url = await getDownloadURL(uploadTask.snapshot.ref);
                        this.imageUrl = url;
                    }
                );
            } catch (err) {
                console.error("Error uploading image:", err);
            }
        },
        async Update(){
            try {
                const res=await axios.patch("/User/update",{
                    username:this.username,
                    email:this.email,
                    phone:this.phone,
                    address:this.address,
                    imageUrl:this.imageUrl
                })
                this.$store.commit('LOGIN_SUCCESS',res.data)
                this.$toast(`Cập nhật thành công`, {
                position: "top-right",
                timeout: 5000
            });
            } catch (err) {
                console.log(err)
                this.$toast(`Cập nhật thất bại`, {
                    position: "top-right",
                    timeout: 5000
                });
            }
        }
    }
}
</script>