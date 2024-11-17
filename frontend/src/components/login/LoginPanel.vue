<template>
    <div id="login-panel" class="w-full dark:bg-black dark:text-white border md:min-w-[23rem] flex flex-col gap-2 p-5">
            <h1 class="text-xl uppercase">{{ $t('login.header') }}</h1>
            <p class="text-gray-400">{{ $t('login.description') }}</p>
            <input type="email" :placeholder="$t('login.inputs.email_placeholder')" v-model="email" class="w-full max-w-full outline-none border p-2 dark:text-black">
            <input type="password" :placeholder="$t('login.inputs.password_placeholder')" v-model="password" class="outline-none border p-2 dark:text-black">
            <p v-if="message" class="text-red-500">{{ message }}</p>
            <button @click="Login" class="bg-black flex justify-center items-center gap-2 text-white dark:bg-white dark:text-black font-bold py-2">
                <VueIcon v-if="$store.state.loading"  type="mdi" :path="mdiRotateRight" class="animate-spin text-white dark:text-black"/>
                {{ $t('login.buttons.submit') }}</button>
            <p class="text-gray-400">{{ $t('login.account_actions.new_user_prompt') }} <span @click="openRegisterPanel" class="text-blue-500 cursor-pointer">{{ $t('login.account_actions.new_user_prompt') }}</span></p>
            <p class="text-gray-400">{{ $t('login.forgot_password.prompt') }} <span @click="openRecoverPanel" class="text-blue-500 cursor-pointer">{{ $t('login.forgot_password.reset_action') }}</span></p>
    </div>
</template>

<script>
import axios from 'axios'
import {mdiRotateRight} from '@mdi/js'
export default {
    name:"LoginPanel",
    props:["getCart"],
    data(){
        return{
            mdiRotateRight,
            email:"",
            password:"",
            message:"",
        }
    },
    methods:{
        async Login(){
            this.$store.commit('LOGIN_START')
            try {
                const res=await axios.post("/User/login",{
                    email:this.email,
                    password:this.password
                })
                this.$store.commit('LOGIN_SUCCESS',res.data)
                this.$toast.success(`Đăng nhập thành công`, {
                    position: "top-right",
                    timeout: 5000
                });
                this.getCart()
                if (this.$store.getters.isAdmin) {
                    this.$router.push('/admin');
                }   
            } catch (err) {
                if(err.response && err.response.data){
                    this.message=err.response.data
                }
                else{
                    this.message="Lỗi kết nối đến server"
                }
                this.$store.commit('LOGIN_FAILURE','')
            }
        },
        openRegisterPanel(){
            this.$emit('openRegisterPanel','register')
        },
        openRecoverPanel(){
            this.$emit('openRecoverPanel','recover')
        }
    }
}
</script>