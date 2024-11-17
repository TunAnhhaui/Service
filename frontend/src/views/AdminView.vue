<template>
    <div className='w-full bg-gray-200'>
        <div v-if="isSidebarVisible" @click="toggleSidebar" class="fixed flex justify-center items-center z-20 inset-0 bg-black bg-opacity-50 h-[100vh] w-[100vw]" ></div>
        <div class="lg:grid grid-cols-12 h-full">
            <div :class="{ 'hidden lg:block': !isSidebarVisible }" class="col-span-2 fixed z-30 min-h-[100vh] lg:h-full bg-black text-white  lg:static lg:z-0 shadow-md">
                <div class="sticky top-1">
                    <div class="flex border-b p-2 gap-1 items-center justify-center border-gray-200 font-bold">
                        <VueIcon type="mdi" :path="mdiViewDashboard" size="20"/>
                        <h1>DASHBOARD</h1>
                    </div>
                    <div class="flex flex-col gap-10">
                        <ul class="">
                            <li><router-link :to="{name:'adminHome',}" class="flex gap-2 items-center p-2  hover:bg-slate-300 hover:text-black rounded-xl">
                                <VueIcon type="mdi" :path="mdiFinance" size="20"/>
                                Thống kê</router-link></li>
                            <li class="block group">
                                <router-link :to="{name:'adminProduct',}" class="flex p-2 items-center gap-2 hover:bg-slate-300 hover:text-black cursor-pointer rounded-xl">
                                    <VueIcon type="mdi" :path="mdiPackageVariantClosed"/>
                                    Quản lý sản phẩm
                                </router-link>
                            </li>
                            <li><router-link :to="{name:'adminCategory',}" class="flex items-center gap-2 p-2 hover:bg-slate-300 hover:text-black rounded-xl">
                                <VueIcon type="mdi" :path="mdiLinkVariant"/>
                                Quản lý danh mục</router-link></li>
                            <li><router-link :to="{name:'imageCollection',}" class="flex items-center p-2 gap-2 hover:bg-slate-300 hover:text-black rounded-xl">
                                <VueIcon type="mdi" :path="mdiImageArea"/>
                                Quản lý ảnh</router-link></li>
                            <li><router-link :to="{name:'adminOrder',}" class="flex items-center gap-2 p-2 hover:bg-slate-300 hover:text-black rounded-xl">
                                <VueIcon type="mdi" :path="mdiShoppingOutline"/>
                                Đơn đặt hàng</router-link></li>
                            <li><router-link :to="{name:'adminUser',}" class="flex items-center gap-2 p-2 hover:bg-slate-300 hover:text-black rounded-xl">
                                <VueIcon type="mdi" :path="mdiAccount"/>
                                Quản lý khách hàng</router-link></li>
                            <li><router-link :to="{name:'voucher',}" class="flex items-center gap-2 p-2 hover:bg-slate-300 hover:text-black rounded-xl">
                                <VueIcon type="mdi" :path="mdiTicketPercentOutline"/>
                                Quản lý voucher</router-link></li>
                            <li><router-link to="" class="flex items-center gap-2 hover:bg-slate-300 p-2 hover:text-black rounded-xl">
                                <VueIcon type="mdi" :path="mdiLogout"/>
                                Logout</router-link></li>
                        </ul>
                        <div @click="toggleSidebar" class="flex lg:hidden bg-gray-900 p-2 justify-center cursor-pointer" ><VueIcon type="mdi" :path="mdiChevronLeft"/></div>
                    </div>
                </div>
            </div>
            <div class="col-span-10 w-full h-full">
                <div class="h-10 flex justify-between">
                    <div class="p-2 flex justify-between lg:justify-end items-center">
                        <div @click="toggleSidebar" class="flex lg:hidden">
                            <VueIcon type="mdi" :path="mdiViewHeadline" size="40" class=" hover:cursor-pointer"/>
                        </div>
                    </div>   
                    <div class="flex items-center gap-2 px-2 cursor-pointer relative group">
                        <img :src="$store.state.user.imageUrl || 'data:image/jpeg;base64,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'" class="w-8 h-8 rounded-full" alt="">
                        <VueIcon type="mdi" :path="mdiChevronDown"/>
                        <div class="absolute hidden group-hover:block top-10 right-5 text-sm z-20 w-24 bg-white text-center shadow-[0px_0px_2px_2px_rgba(0,0,0,0.3)]">
                            <ul class="">
                                <li class="border-b p-2"><a href="/">Đến website</a></li>
                                <li  class="border-b p-2 cursor-pointer">Đăng xuất</li>
                            </ul>
                        </div>
                    </div>                 
                </div>
                <div class="p-5 flex flex-col gap-2 bg-gray-100 min-h-[calc(100vh-40px)]">
                    <router-view ></router-view>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {  mdiChevronDown,mdiChevronLeft,mdiViewHeadline,mdiLogout,mdiShoppingOutline,mdiTicketPercentOutline,mdiViewDashboard,mdiFinance,mdiImageArea, mdiAccount,mdiPackageVariantClosed,mdiLinkVariant } from '@mdi/js';

export default {
    name:'AdminView',
    data(){
        return{
            isSidebarVisible:false,
            userCount:0,
            productCount:0,
            totalCount:0,
            orderCount:0,
            mdiViewHeadline,mdiChevronDown,mdiChevronLeft,mdiLogout,mdiShoppingOutline,mdiTicketPercentOutline,mdiImageArea,mdiViewDashboard,mdiFinance,mdiAccount,mdiPackageVariantClosed,mdiLinkVariant
        }
    },
    methods:{
        toggleSidebar(){
            this.isSidebarVisible=!this.isSidebarVisible
        },
        
    },
    mounted(){

    }
}
</script>