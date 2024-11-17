<template>
  <div id="app" :class="{'dark': isDarkMode}" class="flex flex-col min-h-screen">
    <NavBar v-if="!$route.meta.hideNavbar" :countCart="countCart" :getCart="getCart" :carts="carts" :totalAmount="totalAmount" @toggle-dark-mode="toggleDarkMode"/>
    <router-view :countCart="countCart" :getCart="getCart" :carts="carts" :totalAmount="totalAmount"/>
    <div @click="openSetting" class="fixed right-0 w-3 h-4 bg-yellow-500 bottom-32 flex justify-center items-center cursor-pointer">
      <VueIcon type="mdi" :path="mdiCog " class="absolute right-2 animate-spin z-50 rounded-full bg-yellow-500"/>
      <div @click="scrollToTop()" :class="isSetting ? 'translate-y-0 opacity-100 duration-700' : 'translate-y-10 opacity-0 duration-100'" class="absolute transition-all -top-8 right-2 z-40">
        <VueIcon type="mdi" :path="mdiArrowUpBold" size="25" class="text-blue-500 w-5 h-5 rounded-full hover:bg-gray-700 flex justify-center items-center"/>
      </div>
      <div @click="toggleLanguage" :class="isSetting ? 'translate-x-0 opacity-100 duration-300' : 'translate-x-10 translate-y-10 opacity-0 duration-300'" class="z-40 absolute transition-all -left-12 -top-4 w-5 h-5 rounded-full bg-yellow-400 text-sm font-bold flex justify-center items-center">
        <p>{{ this.$i18n.locale ==='vn' ?'en' :'vn' }}</p>
      </div>
      <div :class="isSetting ? 'translate-x-0 opacity-100 duration-100 ease-in' : 'translate-x-10  opacity-0 duration-700'" class="z-40 absolute transition-all -left-12 top-4 w-5 h-5 rounded-full hover:bg-gray-700 hover:text-white flex justify-center items-center">
        <router-link :to="{name:'home'}"><VueIcon type="mdi" :path="mdiHome" size="25"/></router-link>
      </div>
    </div>
    <Footer v-if="!$route.meta.hideFooter"/>
  </div>
</template>

<script>
import NavBar from './components/navbar/NavBar.vue'
import Footer from './components/footer/Footer.vue'
import {mdiCog,mdiArrowUpBold,mdiHome,mdiMessageText,mdiChevronDownBoxOutline } from "@mdi/js"
import axios from 'axios';
export default {
  components:{
    NavBar,
    Footer,
  },
  data(){
    return{
      isDarkMode :localStorage.getItem('darkMode')==='true' || false,
      mdiCog,mdiArrowUpBold,mdiHome,mdiMessageText,mdiChevronDownBoxOutline,
      isSetting:false,
      countCart:0,
      totalAmount:0,
      carts:""
    }
  },
  mounted(){
        this.getCart()
        this.isDarkMode = localStorage.getItem('darkMode') === 'true';
    },
    watch: {
      isDarkMode(newValue) {
        localStorage.setItem('darkMode', newValue);
      },
    },
  methods:{
    toggleDarkMode() {
      this.isDarkMode = !this.isDarkMode;
      localStorage.setItem('darkMode', this.isDarkMode);
    },
    scrollToTop(){
      window.scrollTo({top:0,behavior:"smooth"})
    },
    openSetting(){
      this.isSetting=!this.isSetting
    },
    toggleLanguage() {
      if(this.$i18n.locale=='vn'){
        this.$i18n.locale='en'
      }else{
        this.$i18n.locale='vn'
      }
    },
    async getCart(){
      try {
        const res=await axios.get('/Cart/getCart')
        this.countCart=res.data.carts.length
        this.carts=res.data.carts
        this.totalAmount=res.data.totalAmount
      } catch (err) {
        if (err.response && err.response.status === 401) {
          this.countCart = 0;
        }
        console.error(err)
      }
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>
