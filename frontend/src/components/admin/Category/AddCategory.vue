<template>
    <div v-if="open" class="fixed flex justify-center items-center z-20 inset-0 bg-black bg-opacity-50 h-[100vh] w-full" >
        <div  class=" bg-white w-full mx-auto md:w-1/2">
            <div class="text-center relative">
                <h1 class="uppercase font-bold text-xl bg-[#271511] text-white p-2">Thêm thể loại</h1>
                <div @click="close">
                    <VueIcon type="mdi" :path="mdiClose" size="30" class="absolute top-0 right-0 hover:cursor-pointer text-white  hover:bg-red-500"/>
                </div>
            </div>
            <div class="flex flex-col gap-5 p-5">
                <input type="text" name="name" v-model="name" placeholder="Tên thể loại" class="border-b w-full p-2">
                <div class="flex gap-5">
                    <select name="" id="" v-model="categoryTypeId" class="p-2 w-40 h-10 border outline-none">
                        <option value="" selected>Danh mục</option>
                        <option v-for="item in categoryType" :key="item.categoryTypeId" :value="item.categoryTypeId">{{ item.name }}</option>
                    </select>
                </div>
                <button @click="AddCategory" class="float-end p-2 bg-blue-400 shadow-md z-10 rounded-md">Lưu</button>
            </div>
        </div>
    </div>

</template>
<script>
import { mdiCamera, mdiClose } from '@mdi/js';
import axios from 'axios';

export default {
    name:"AddCategory",
    props:['open','getcategory'],
    data(){
        return{
            name:'',
            categoryTypeId:"",
            mdiClose,mdiCamera,
            percent:0,
            categoryType:""
        }
    },
    mounted(){
        this.getCategoryType()
    },
    methods:{
        close(){
            this.$emit('close');
        },
        async getCategoryType(){
            try {
                const res=await axios.get("/CategoryType/getAll")
                this.categoryType=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async AddCategory(){
            try {
                await axios.post("/Category/create",{
                    name:this.name,
                    categoryTypeId:this.categoryTypeId
                })
                this.getcategory()
                this.close()
                this.$toast(`Thêm thành công`, {
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