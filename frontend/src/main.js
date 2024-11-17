import Vue from 'vue'
import App from './App.vue'
import './assets/tailwind.css'
import router from './router'
import VueIcon from '@jamescoyle/vue-icon';
import VueI18n from 'vue-i18n'
import vnMessage from './lang/vn.json'
import enMessage from './lang/en.json'
import store from '../src/store/store'
import VueApexCharts from 'vue-apexcharts'
import './axios'
import Toast from "vue-toastification";
import "vue-toastification/dist/index.css";
Vue.use(VueApexCharts)

Vue.component('apexChart', VueApexCharts)
import VueNumeralFilterInstaller from 'vue-numeral-filter';

Vue.use(VueNumeralFilterInstaller);
import ToggleButton from 'vue-js-toggle-button'

Vue.use(ToggleButton)
import 'viewerjs/dist/viewer.css'
import Viewer from 'v-viewer'
Vue.use(Viewer)
Vue.use(Toast);
Vue.config.productionTip = false
Vue.component('VueIcon', VueIcon);
Vue.use(VueI18n)
const messages = {
  vn: vnMessage,
  en: enMessage,
}
const i18n = new VueI18n({
  locale: 'vn', 
  messages,
  fallbackLocale: 'vn',
})
new Vue({
  router,
  store,
  i18n,
  render: h => h(App)
}).$mount('#app')
