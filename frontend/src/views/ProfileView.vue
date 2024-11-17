<template>
    <div class="flex flex-col ">
        <div class="flex flex-wrap gap-2 items-center text-xs md:text-sm px-5 md:px-10 py-2 bg-gray-100 text-gray-500">
            <router-link :to="{name:'home'}">Trang chủ </router-link>/ <p>Trang khách hàng</p>
        </div>
        <div class="p-5 dark:bg-black dark:text-white">
            <div class="flex flex-col md:grid grid-cols-12 gap-5">
                <div class="col-span-3 md:col-span-4">
                    <div @click="showMenu" class="flex items-center justify-between cursor-pointer bg-black text-white dark:bg-white dark:text-black text-center p-2">
                        <div class="flex items-center gap-5">
                            <img :src="$store.state.user.imageUrl || 'data:image/jpeg;base64,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'" alt="" class="w-10 h-10 rounded-full">
                            <div class="flex flex-col text-xs gap-1">
                                <p>{{ $store.state.user.username ||  $store.state.user.email}}</p>
                                <router-link :to="{name:'account'}" class="flex item-center text-gray-300 dark:text-black"><VueIcon type="mdi" :path="mdiPencil" size="15"/> Sửa hồ sơ</router-link>
                            </div>
                        </div>
                        <VueIcon type="mdi" :path="menu ? mdiChevronUp :mdiChevronDown" class="text-white dark:text-black"/>
                    </div>
                    <ul v-if="menu" class="py-2 text-sm bg-gray-100 dark:bg-black dark:text-white border">
                        <li><router-link :to="{name:'account'}" class="flex hover:text-yellow-600 hover:bg-gray-700 p-2">Thông tin tài khoản</router-link></li>
                        <li><router-link :to="{name:'changePass'}" class="flex hover:text-yellow-600 hover:bg-gray-700 p-2">Đơn hàng của bạn</router-link></li>
                        <li><router-link :to="{name:'order'}" class="flex hover:text-yellow-600 hover:bg-gray-700 p-2">Đổi mật khẩu</router-link></li>
                    </ul>
                </div>
                <div class="col-span-9 md:col-span-8    ">
                    <router-view></router-view>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import { mdiChevronUp,mdiChevronDown, mdiPencil} from '@mdi/js';

export default {
    name:"ProfileView",
    data(){
        return{
            menu:true,
            mdiChevronDown,mdiChevronUp,mdiPencil
        }
    },
    methods:{
        showMenu(){
           this.menu=!this.menu 
        }
    }
}
</script>