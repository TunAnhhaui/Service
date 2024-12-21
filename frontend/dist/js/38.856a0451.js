"use strict";(self["webpackChunkfrontend"]=self["webpackChunkfrontend"]||[]).push([[38],{4038:function(t,e,a){a.r(e),a.d(e,{default:function(){return v}});var o=function(){var t=this,e=t._self._c;return e("div",{staticClass:"mt-2"},[e("div",{staticClass:"flex items-center gap-2 p-2"},[e("router-link",{attrs:{to:{name:"adminHome"}}},[t._v("Home:")]),e("VueIcon",{attrs:{type:"mdi",path:t.mdiChevronRight}}),e("p",{staticClass:"text-sm"},[t._v("Danh mục")])],1),e("div",{staticClass:"flex flex-col gap-5 bg-white shadow-lg mt-1 p-4"},[e("div",{staticClass:"flex justify-between"},[e("select",{directives:[{name:"model",rawName:"v-model",value:t.categoryTypeId,expression:"categoryTypeId"}],staticClass:"p-1 outline-none border",attrs:{name:""},on:{change:function(e){var a=Array.prototype.filter.call(e.target.options,(function(t){return t.selected})).map((function(t){var e="_value"in t?t._value:t.value;return e}));t.categoryTypeId=e.target.multiple?a:a[0]}}},[e("option",{attrs:{value:""}},[t._v("Tất cả")]),t._l(t.categoryType,(function(a){return e("option",{key:a.categoryTypeId,domProps:{value:a.categoryTypeId}},[t._v(t._s(a.name))])}))],2),e("div",{staticClass:"text-blue-500 flex items-center gap-2 bg-blue-100 p-1 text-sm cursor-pointer",on:{click:t.handleAdd}},[e("VueIcon",{attrs:{type:"mdi",path:t.mdiCogOutline,size:"15"}}),t._v(" Thêm thể loại ")],1)]),e("table",{staticClass:"w-full"},[t._m(0),e("tbody",t._l(t.data,(function(a){return e("tr",{key:a.categoryId},[e("td",{staticClass:"border text-center",attrs:{scope:"col"}},[t._v(t._s(a.name))]),e("td",{staticClass:"border flex items-center justify-center gap-2 text-white",attrs:{scope:"col"}},[e("div",{staticClass:"p-1 bg-red-500 rounded-lg",on:{click:function(e){return t.handleDelete(a.categoryId)}}},[e("VueIcon",{staticClass:"hover:cursor-pointer",attrs:{type:"mdi",path:t.mdiTrashCanOutline,size:"20"}})],1)])])})),0)])]),e("AddCategory",{attrs:{open:t.add,getcategory:t.getcategory},on:{close:t.handleClose}})],1)},s=[function(){var t=this,e=t._self._c;return e("thead",{staticClass:"border"},[e("tr",{staticClass:"bg-gray-400"},[e("th",{staticClass:"border",attrs:{scope:"col"}},[t._v("Tên thể loại")]),e("th",{staticClass:"border",attrs:{scope:"col"}},[t._v("Hành động")])])])}],r=a(4373),i=function(){var t=this,e=t._self._c;return t.open?e("div",{staticClass:"fixed flex justify-center items-center z-20 inset-0 bg-black bg-opacity-50 h-[100vh] w-full"},[e("div",{staticClass:"bg-white w-full mx-auto md:w-1/2"},[e("div",{staticClass:"text-center relative"},[e("h1",{staticClass:"uppercase font-bold text-xl bg-[#271511] text-white p-2"},[t._v("Thêm thể loại")]),e("div",{on:{click:t.close}},[e("VueIcon",{staticClass:"absolute top-0 right-0 hover:cursor-pointer text-white hover:bg-red-500",attrs:{type:"mdi",path:t.mdiClose,size:"30"}})],1)]),e("div",{staticClass:"flex flex-col gap-5 p-5"},[e("input",{directives:[{name:"model",rawName:"v-model",value:t.name,expression:"name"}],staticClass:"border-b w-full p-2",attrs:{type:"text",name:"name",placeholder:"Tên thể loại"},domProps:{value:t.name},on:{input:function(e){e.target.composing||(t.name=e.target.value)}}}),e("div",{staticClass:"flex gap-5"},[e("select",{directives:[{name:"model",rawName:"v-model",value:t.categoryTypeId,expression:"categoryTypeId"}],staticClass:"p-2 w-40 h-10 border outline-none",attrs:{name:"",id:""},on:{change:function(e){var a=Array.prototype.filter.call(e.target.options,(function(t){return t.selected})).map((function(t){var e="_value"in t?t._value:t.value;return e}));t.categoryTypeId=e.target.multiple?a:a[0]}}},[e("option",{attrs:{value:"",selected:""}},[t._v("Danh mục")]),t._l(t.categoryType,(function(a){return e("option",{key:a.categoryTypeId,domProps:{value:a.categoryTypeId}},[t._v(t._s(a.name))])}))],2)]),e("button",{staticClass:"float-end p-2 bg-blue-400 shadow-md z-10 rounded-md",on:{click:t.AddCategory}},[t._v("Lưu")])])])]):t._e()},n=[],c=a(2132),l={name:"AddCategory",props:["open","getcategory"],data(){return{name:"",categoryTypeId:"",mdiClose:c.hyP,mdiCamera:c.KgF,percent:0,categoryType:""}},mounted(){this.getCategoryType()},methods:{close(){this.$emit("close")},async getCategoryType(){try{const t=await r.A.get("/CategoryType/getAll");this.categoryType=t.data}catch(t){console.log(t)}},async AddCategory(){try{await r.A.post("/Category/create",{name:this.name,categoryTypeId:this.categoryTypeId}),this.getcategory(),this.close(),this.$toast("Thêm thành công",{position:"top-right",timeout:5e3})}catch(t){console.log(t)}}}},d=l,g=a(1656),y=(0,g.A)(d,i,n,!1,null,null,null),p=y.exports,h={name:"CategoryView",components:{AddCategory:p},data(){return{add:!1,data:[],page:1,limit:999,mdiTrashCanOutline:c.FhF,mdiEyedropperVariant:c.xeK,mdiChevronRight:c.mI8,mdiCogOutline:c.ED,mdiEyeOutline:c._r5,categoryType:"",categoryTypeId:""}},created(){this.getcategory(),this.getcategoryType()},watch:{categoryTypeId:function(){""!=this.categoryTypeId?this.getcategoryByType():this.getcategory()}},methods:{async getcategory(){try{const t=await r.A.get(`/Category/getByPage?page=${this.page}&limit=${this.limit}`);this.data=t.data}catch(t){console.log(t)}},async getcategoryByType(){try{const t=await r.A.get(`/Category/getByCategoryType/${this.categoryTypeId}`);this.data=t.data}catch(t){console.log(t)}},async getcategoryType(){try{const t=await r.A.get("/CategoryType/getAll");this.categoryType=t.data}catch(t){console.log(t)}},async handleDelete(t){const e=confirm("Bạn có chắc chắn muốn xóa không?");if(e)try{await r.A.delete("/Category/delete/"+t),this.getcategory(),this.$toast("Xóa thành công",{position:"top-right",timeout:5e3})}catch(a){console.log(a),this.$toast("Xóa thất bại",{position:"top-right",timeout:5e3})}},handleAdd(){this.add=!0},handleClose(){this.add=!1}}},u=h,m=(0,g.A)(u,o,s,!1,null,null,null),v=m.exports}}]);
//# sourceMappingURL=38.856a0451.js.map