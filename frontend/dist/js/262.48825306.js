"use strict";(self["webpackChunkfrontend"]=self["webpackChunkfrontend"]||[]).push([[262],{3262:function(t,e,s){s.r(e),s.d(e,{default:function(){return u}});var r=function(){var t=this,e=t._self._c;return e("div",{staticClass:"mt-2 relative"},[e("div",{staticClass:"flex items-center gap-2 p-2"},[e("router-link",{attrs:{to:{name:"adminHome"}}},[t._v("Home:")]),e("VueIcon",{attrs:{type:"mdi",path:t.mdiChevronRight}}),e("p",{staticClass:"text-sm"},[t._v("Đơn hàng")])],1),e("div",{staticClass:"bg-white shadow-lg mt-1"},[e("table",{staticClass:"w-full text-xs"},[t._m(0),e("tbody",[t._l(t.data,(function(s){return e("tr",{key:s.orderId},[e("td",{staticClass:"border text-center hover:text-blue-500 cursor-pointer",attrs:{scope:"col"},on:{click:function(e){return t.toggleDetails(s.orderId)}}},[t._v("#"+t._s(s.orderId))]),e("td",{staticClass:"border text-center",attrs:{scope:"col"}},[t._v(t._s(t.formatDate(s.createDate)))]),e("td",{staticClass:"border text-center",attrs:{scope:"col"}},[t._v(t._s(t._f("numeral")(s.totalAmount))+" đ")]),e("td",{staticClass:"border text-center",attrs:{scope:"col"}},[t._v(t._s(s.paymentStatus))]),e("td",{staticClass:"border text-center",attrs:{scope:"col"}},[t._v(t._s(s.shippingStatus))]),e("td",{staticClass:"flex gap-2 justify-center items-center border"},[e("div",{staticClass:"cursor-pointer",class:"Đã giao"===s.shippingStatus?"text-blue-500":"text-red-500",on:{click:function(e){return t.Update(s.orderId,s.paymentStatus,s.shippingStatus)}}},[e("VueIcon",{attrs:{type:"mdi",path:t.mdiCheckCircle}})],1),e("div",{staticClass:"text-red-500"},[e("VueIcon",{attrs:{type:"mdi",path:t.mdiCloseCircle}})],1)])])})),t.selectedOrderId===t.orderDetail.orderId?e("tr",[e("td",{staticClass:"p-4",attrs:{colspan:"6"}},[e("div",{staticClass:"bg-gray-100 p-2"},[e("p",[e("strong",[t._v("Chi tiết đơn hàng #"+t._s(t.orderDetail.orderId))])]),e("p",[t._v("Khách hàng: "+t._s(t.orderDetail.user.username))]),e("p",[t._v("Địa chỉ: "+t._s(t.orderDetail.address))]),e("p",[t._v("Số điện thoại: "+t._s(t.orderDetail.phone))])])])]):t._e()],2)])])])},a=[function(){var t=this,e=t._self._c;return e("thead",{staticClass:"border"},[e("tr",{staticClass:"bg-gray-400 text-center"},[e("td",{staticClass:"p-2 border",attrs:{scope:"col"}},[t._v("Đơn hàng")]),e("td",{staticClass:"p-2 border",attrs:{scope:"col"}},[t._v("Ngày")]),e("td",{staticClass:"p-2 border",attrs:{scope:"col"}},[t._v("Đơn giá")]),e("td",{staticClass:"p-2 border",attrs:{scope:"col"}},[t._v("Thanh toán")]),e("td",{staticClass:"p-2 border",attrs:{scope:"col"}},[t._v("Vận chuyển")]),e("td",{staticClass:"p-2 border",attrs:{scope:"col"}},[t._v("Hành động")])])])}],i=s(2132),d=s(4373),o=s(9148),c=s.n(o),l={name:"OrderView",props:["updateTotal"],data(){return{data:[],page:1,limit:20,mdiChevronRight:i.mI8,mdiCheckCircle:i.NG3,mdiCloseCircle:i.BCx,selectedOrderId:null,orderDetail:""}},mounted(){this.getOrder()},methods:{formatDate(t){return c()(t).format("YYYY-MM-DD")},toggleDetails(t){this.selectedOrderId=this.selectedOrderId===t?null:t,this.getOrderDetail()},async getOrder(){try{const t=await d.A.get(`/Order/GetAll?page=${this.page}&limit=${this.limit}`);this.data=t.data}catch(t){console.log(t)}},async getOrderDetail(){try{const t=await d.A.get(`/Order/GetById/${this.selectedOrderId}`);this.orderDetail=t.data}catch(t){console.log(t)}},async Update(t,e,s){try{let e,s;e="Đã thanh toán",s="Đã giao",await d.A.patch(`/Order/update/${t}`,{paymentStatus:e,shippingStatus:s}),this.getOrder()}catch(r){console.log(r)}}}},n=l,p=s(1656),h=(0,p.A)(n,r,a,!1,null,null,null),u=h.exports}}]);
//# sourceMappingURL=262.48825306.js.map