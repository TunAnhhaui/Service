<template>
    <div class=" mt-2">
        <div class="flex items-center gap-2 p-2">
            <router-link :to="{name:'adminHome'}">Home:</router-link>
            <VueIcon type="mdi" :path="mdiChevronRight"/>
            <p class="text-sm">Danh mục</p>
        </div>
        <div class="flex flex-col gap-5 bg-white shadow-lg mt-1 p-4">
            <div class="flex justify-between">
                <select name="" v-model="categoryTypeId" class="p-1 outline-none border">
                    <option value="">Tất cả</option>
                    <option v-for="item in categoryType" :key="item.categoryTypeId" :value="item.categoryTypeId">{{ item.name }}</option>
                </select>
                <div @click="handleAdd" class="text-blue-500 flex items-center gap-2 bg-blue-100 p-1 text-sm cursor-pointer">
                    <VueIcon type="mdi" :path="mdiCogOutline" size="15"/>
                    Thêm thể loại
                </div>
            </div>
            <table class="w-full">
                <thead class="border">
                    <tr class="bg-gray-400">
                        <th scope="col" class="border">Tên thể loại</th>
                        <th scope="col" class="border">Hành động</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in data" :key="item.categoryId">
                        <td scope="col" class="border text-center">{{ item.name }}</td>
                        <td scope="col" class=" border flex items-center justify-center gap-2 text-white">
                            <div @click="handleDelete(item.categoryId)" class="p-1 bg-red-500 rounded-lg">
                                <VueIcon type="mdi" :path="mdiTrashCanOutline"  class=" hover:cursor-pointer" size="20"/>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <AddCategory :open="add" :getcategory="getcategory" @close="handleClose"/>
    </div>
</template>
<script>
import axios from 'axios'
import AddCategory from './AddCategory.vue'
import {mdiTrashCanOutline,mdiEyedropperVariant, mdiChevronRight, mdiCogOutline,mdiEyeOutline} from "@mdi/js"

export default {
    name:'CategoryView',
    components:{AddCategory},
    data(){
        return{
            add:false,
            data:[],
            page:1,
            limit:999,
            mdiTrashCanOutline,mdiEyedropperVariant,mdiChevronRight,mdiCogOutline,mdiEyeOutline,
            categoryType:"",
            categoryTypeId:""
        }
    },
    created(){
        this.getcategory();
        this.getcategoryType()
    },
    watch:{
        "categoryTypeId":function(){
            if(this.categoryTypeId !=""){
                this.getcategoryByType()
            }else{
                this.getcategory()
            }
        }
    },
    methods:{
        async getcategory(){
            try {
                const res=await axios.get(`/Category/getByPage?page=${this.page}&limit=${this.limit}`)
                this.data=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async getcategoryByType(){
            try {
                const res=await axios.get(`/Category/getByCategoryType/${this.categoryTypeId}`)
                this.data=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async getcategoryType(){
            try {
                const res=await axios.get(`/CategoryType/getAll`)
                this.categoryType=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async handleDelete(id){
            const confirmed = confirm("Bạn có chắc chắn muốn xóa không?");
            if (confirmed) {
                try {
                    await axios.delete('/Category/delete/'+id)
                    this.getcategory();
                    this.$toast(`Xóa thành công`, {
                        position: "top-right",
                        timeout: 5000
                    });
                } catch (err) {
                    console.log(err)
                    this.$toast(`Xóa thất bại`, {
                        position: "top-right",
                        timeout: 5000
                    });
                }
            }
        },
        handleAdd(){
            this.add=true;
        },
        handleClose(){
            this.add = false;
        },
    },
}
</script>