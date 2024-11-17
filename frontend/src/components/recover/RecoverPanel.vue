<template>
    <div id="recover-panel" class="w-full h-full md:min-w-[23rem] flex flex-col gap-2 p-5 dark:bg-black dark:text-white border">
            <h1 class="text-xl uppercase">{{ $t('recover.header') }}</h1>
            <div class="flex flex-col gap-2">
                <input type="email" v-model="email" :placeholder="$t('recover.inputs.email_placeholder')" class="outline-none border p-2 dark:text-black">
                <p v-if="message" class="text-red-500">{{ message }}</p>
                <button @click="recoverHandle" class="bg-black text-white dark:bg-white dark:text-black font-bold py-2">{{ $t('recover.buttons.recover') }}</button>
                <p class="text-gray-400">{{ $t('recover.return_to_login') }} <span @click="openLoginPanel" class="text-blue-500 cursor-pointer">{{ $t('recover.back_to_login') }}</span></p>
            </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name:"RecoverPanel",
    data(){
        return{
            email:"",
            message:"",
            
        }
    },
    methods:{
        openLoginPanel(){
            this.$emit('openLoginPanel','login')
        },
        async recoverHandle(){
            try {
                const res=await axios.post("/User/recover",{email:this.email})
                this.message=res.data
            } catch (err) {
                if(err.response){
                    this.message=err.response.data
                }
                else{
                    this.message="Lỗi kết nối đến server"
                }
            }
        }
    }
}
</script>