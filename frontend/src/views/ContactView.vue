<template>
    <div class="flex flex-col ">
        <div class="flex flex-wrap gap-2 items-center text-xs md:text-sm px-5 md:px-10 py-2 bg-gray-100 text-gray-500">
            <a href="/">Trang chủ </a>/ <p>Liên hệ</p>
        </div>
        <div class="p-5 md:p-10 flex flex-col gap-5 dark:bg-black dark:text-white">
            <div class="grid grid-cols-1 md:grid-cols-2 gap-5">
                <div class="col-span-1">
                    <img src="https://theme.hstatic.net/200000065946/1001264503/14/show_image_footers.jpg?v=339" alt="" class="w-full h-auto">
                </div>
                <div class="col-span-1 flex flex-col gap-2">
                    <h1 class="self-center font-bold text-xl">Thông tin liên hệ</h1>
                    <div class="flex flex-col gap-2">
                        <p class="text-gray-500">Địa chỉ chúng tôi</p>
                        <div class="flex  flex-col gap-3">
                            <p class="font-bold">[Ho Chi Minh City]</p>
                            <p class="flex flex-col text-sm font-bold">162 HT17, P. Hiệp Thành, Q. 12, TP. HCM (Nằm trong khuôn viên công ty SAVIMEX phía sau bến xe buýt Hiệp Thành)
                                <span>Hotline: 0971 141 140</span></p>
                            <p class="flex flex-col text-sm font-bold">S05.03-S18 phân khu The Rainbow | Vinhomes Grand Park, TP. Thủ Đức.
                                <span>Hotline: 0931 880 424</span></p>
                        </div>
                        <div class="flex  flex-col gap-3">
                            <p class="font-bold">[Ha Noi City]</p>
                            <p class="flex flex-col text-sm font-bold">S3.03-Sh15 phân khu Sapphire | Vinhomes Smart City, Hà Nội .
                                <span>Hotline: 0909 665 728</span></p>
                            <p class="flex flex-col text-sm font-bold">S2.09-Sh19 phân khu Sapphire | Vinhomes Ocean Park, Hà Nội.
                                <span>Hotline: 0938 108 772</span></p>
                        </div>
                    </div>
                    <div class="flex flex-col">
                        <p class="text-gray-500">Email chúng tôi</p>
                        <p class="font-bold">cskh@moho.com.vn</p>
                    </div>
                    <div class="flex flex-col">
                        <p class="text-gray-500">Điện thoại</p>
                        <p class="font-bold">097 114 1140 (Hotline/Zalo)</p>
                    </div>
                    <div class="flex flex-col">
                        <p class="text-gray-500">Thời gian làm việc</p>
                        <p class="font-bold">08:00 - 20:00</p>
                        <p class="font-bold">Thứ 2 - Chủ Nhật</p>
                    </div>
                </div>
            </div>
            <div class="flex">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d672.9175159387886!2d106.6412116333496!3d10.87710165714945!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317529e2c5230189%3A0xb62a1a12ab91f10e!2sSavimex%20Corporation!5e0!3m2!1svi!2s!4v1724137536427!5m2!1svi!2s"
                onplay="lazy" class="w-screen h-96"/>
            </div>
            <div class="flex flex-col w-full items-center gap-5 sm:px-20">
                <h1 class="font-bold text-xl">Gửi thắc mắc cho chúng tôi</h1>
                <div class="flex flex-col md:flex-row gap-5 w-full">
                    <input type="text" placeholder="Tên của bạn" v-model="name" class="w-full md:w-1/3 border dark:bg-black dark:text-white outline-none p-2">
                    <input type="text" placeholder="Email của bạn" v-model="email" class="w-full md:w-1/3 border outline-none dark:bg-black dark:text-white p-2">
                    <input type="text" placeholder="Số điện thoại của bạn" v-model="phone" class="w-full md:w-1/3 border dark:bg-black dark:text-white outline-none p-2">
                </div>
                <input type="text" placeholder="Tiêu đề" v-model="title" class="w-full border dark:bg-black dark:text-white outline-none p-2">
                <textarea placeholder="Nội dung" rows="4" v-model="description" class="border outline-none p-2 w-full dark:bg-black dark:text-white"></textarea>
                <button @click="sendEmail" class="p-2 text-white bg-black text-xl dark:bg-white dark:text-black">Gửi cho chúng tôi</button>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name:"ContactView",
    data(){
        return{
            name:"",
            email:"",
            phone:"",
            title:"",
            description:""
        }
    },
    methods:{
        async sendEmail(){
            try {
                await axios.post("/User/sendEmailContact",{
                    name:this.name,
                    email:this.email,
                    phone:this.phone,
                    title:this.title,
                    description:this.description
                })
                this.$toast.success(`Gửi email thành công`, {
                    position: "top-right",
                    timeout: 5000
                });
            } catch (err) {
                this.$toast.error(`Gửi email thất bại`, {
                    position: "top-right",
                    timeout: 5000
                });
                console.log(err)
            }
        }
    }
}
</script>