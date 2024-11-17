"use strict";(self["webpackChunkfrontend"]=self["webpackChunkfrontend"]||[]).push([[208],{9208:function(t,e,a){a.r(e),a.d(e,{default:function(){return P}});var s=function(){var t=this,e=t._self._c;return e("div",{staticClass:"mt-2 relative"},[e("div",{staticClass:"flex items-center gap-2 p-2"},[e("router-link",{attrs:{to:{name:"adminHome"}}},[t._v("Home:")]),e("VueIcon",{attrs:{type:"mdi",path:t.mdiChevronRight}}),e("p",{staticClass:"text-sm"},[t._v("Sản phẩm")])],1),e("div",{staticClass:"flex flex-col gap-5 bg-white shadow-lg mt-1 p-4"},[e("div",{staticClass:"flex justify-between"},[e("select",{directives:[{name:"model",rawName:"v-model",value:t.categoryId,expression:"categoryId"}],staticClass:"p-1 outline-none border",attrs:{name:""},on:{change:function(e){var a=Array.prototype.filter.call(e.target.options,(function(t){return t.selected})).map((function(t){var e="_value"in t?t._value:t.value;return e}));t.categoryId=e.target.multiple?a:a[0]}}},[e("option",{attrs:{value:""}},[t._v("Tất cả")]),t._l(t.categorys,(function(a){return e("option",{key:a.categoryId,domProps:{value:a.categoryId}},[t._v(t._s(a.name))])}))],2),e("div",{staticClass:"text-blue-500 flex items-center gap-2 bg-blue-100 p-1 text-sm cursor-pointer",on:{click:t.handleAdd}},[e("VueIcon",{attrs:{type:"mdi",path:t.mdiCogOutline,size:"15"}}),t._v(" Thêm mặt hàng ")],1)]),e("table",{staticClass:"w-full text-xs md:text-sm"},[t._m(0),e("tbody",t._l(t.data,(function(a){return e("tr",{key:a.productId},[e("td",{staticClass:"border p-2",attrs:{scope:"col"}},[t._v(t._s(a.name))]),e("td",{staticClass:"border text-center",attrs:{scope:"col"}},[e("div",{directives:[{name:"viewer",rawName:"v-viewer"}],staticClass:"flex justify-center"},[e("img",{staticClass:"w-10 h-10",attrs:{src:a.image,alt:""}})]),e("viewer",{attrs:{src:a.image}},[e("img",{attrs:{src:t.src}})])],1),e("td",{staticClass:"border text-center",attrs:{scope:"col"}},[t._v(t._s(t._f("numeral")(a.price)))]),e("td",{staticClass:"border text-center",attrs:{scope:"col"}},[t._v(t._s(a.averageRate))]),e("td",{staticClass:"border text-center",attrs:{scope:"col"}},[t._v(t._s(a.sell||0))]),e("td",{staticClass:"border text-center",attrs:{scope:"col"}},[e("div",{staticClass:"flex items-center justify-center text-white"},[e("div",{staticClass:"p-1 bg-blue-500 rounded-lg",on:{click:function(e){return t.handleUpdate(a.productId)}}},[e("VueIcon",{staticClass:"hover:cursor-pointer",attrs:{type:"mdi",path:t.mdiEyedropperVariant,size:"15"}})],1),e("router-link",{staticClass:"p-1 bg-yellow-500 rounded-lg",attrs:{to:{name:"detail",query:{msp:a.productId}}}},[e("VueIcon",{staticClass:"hover:cursor-pointer",attrs:{type:"mdi",path:t.mdiEyeOutline,size:"15"}})],1),e("div",{staticClass:"p-1 bg-red-500 rounded-lg",on:{click:function(e){return t.handleDelete(a.productId)}}},[e("VueIcon",{staticClass:"hover:cursor-pointer",attrs:{type:"mdi",path:t.mdiTrashCanOutline,size:"15"}})],1)],1)])])})),0)])]),e("AddProduct",{attrs:{open:t.add,getproduct:t.getproduct},on:{close:t.handleClose}}),e("EditProduct",{attrs:{open:t.update,productIdToUpdate:t.productIdToUpdate,getproduct:t.getproduct},on:{close:t.handleClose}})],1)},o=[function(){var t=this,e=t._self._c;return e("thead",{staticClass:"border"},[e("tr",{staticClass:"bg-gray-400"},[e("th",{staticClass:"border",attrs:{scope:"col"}},[t._v("Tên mặt hàng")]),e("th",{staticClass:"border",attrs:{scope:"col"}},[t._v("Ảnh")]),e("th",{staticClass:"border",attrs:{scope:"col"}},[t._v("Giá bán")]),e("th",{staticClass:"border",attrs:{scope:"col"}},[t._v("Đánh giá")]),e("th",{staticClass:"border",attrs:{scope:"col"}},[t._v("Đã bán")]),e("th",{staticClass:"border",attrs:{scope:"col"}},[t._v("Hành động")])])])}],r=function(){var t=this,e=t._self._c;return t.open?e("div",{staticClass:"fixed flex justify-center items-center z-20 inset-0 bg-black bg-opacity-50 h-[100vh] w-full"},[e("div",{staticClass:"bg-white w-full max-auto md:w-1/2"},[e("div",{staticClass:"text-center relative"},[e("h1",{staticClass:"uppercase font-bold text-xl bg-[#271511] text-white p-2"},[t._v("Thêm sản phẩm")]),e("div",{on:{click:t.close}},[e("VueIcon",{staticClass:"absolute top-0 right-0 hover:cursor-pointer text-white hover:bg-red-500",attrs:{type:"mdi",path:t.mdiClose,size:"30"}})],1)]),e("div",{staticClass:"flex flex-col gap-5 p-5"},[e("input",{directives:[{name:"model",rawName:"v-model",value:t.name,expression:"name"}],staticClass:"border-b w-full p-2",attrs:{type:"text",name:"name",placeholder:"Tên sản phẩm"},domProps:{value:t.name},on:{input:function(e){e.target.composing||(t.name=e.target.value)}}}),e("div",{staticClass:"flex gap-5"},[e("div",[e("label",{attrs:{for:"Price"}},[t._v("Giá")]),e("input",{directives:[{name:"model",rawName:"v-model",value:t.price,expression:"price"}],staticClass:"border-b w-full p-2",attrs:{type:"number",id:"Price",placeholder:"Giá"},domProps:{value:t.price},on:{input:function(e){e.target.composing||(t.price=e.target.value)}}})]),e("div",[e("label",{attrs:{for:"Discounted"}},[t._v("Ưu đãi %")]),e("input",{directives:[{name:"model",rawName:"v-model",value:t.discounted,expression:"discounted"}],staticClass:"border-b w-full p-2",attrs:{type:"number",id:"Discounted",placeholder:"Ưu đãi %"},domProps:{value:t.discounted},on:{input:function(e){e.target.composing||(t.discounted=e.target.value)}}})])]),e("textarea",{directives:[{name:"model",rawName:"v-model",value:t.description,expression:"description"}],staticClass:"border-b w-full p-2",attrs:{placeholder:"Mô tả"},domProps:{value:t.description},on:{input:function(e){e.target.composing||(t.description=e.target.value)}}}),t._v(" "),e("div",{staticClass:"flex gap-5"},[e("select",{directives:[{name:"model",rawName:"v-model",value:t.categoryId,expression:"categoryId"}],staticClass:"p-2 w-40 h-10 border outline-none",attrs:{name:"",id:""},on:{change:function(e){var a=Array.prototype.filter.call(e.target.options,(function(t){return t.selected})).map((function(t){var e="_value"in t?t._value:t.value;return e}));t.categoryId=e.target.multiple?a:a[0]}}},[e("option",{attrs:{value:"",selected:""}},[t._v("Danh mục")]),t._l(t.listCategory,(function(a){return e("option",{key:a.categoryId,domProps:{value:a.categoryId}},[t._v(t._s(a.name))])}))],2),e("div",{staticClass:"flex"},[t.image?e("div",{staticClass:"relative"},[e("img",{staticClass:"w-10 h-10 md:w-20 md:h-20 border-2 text-2xl block hover:cursor-pointer",attrs:{src:t.image,alt:""}}),e("div",{on:{click:t.remove}},[e("VueIcon",{staticClass:"absolute top-0 right-0 p-1 hover:cursor-pointer border bg-slate-100 rounded-[50%]",attrs:{type:"mdi",path:t.mdiClose}})],1)]):e("label",{staticClass:"w-10 h-10 md:w-20 md:h-20 border-2 flex justify-center items-center hover:cursor-pointer",attrs:{for:"file"}},[e("VueIcon",{attrs:{type:"mdi",path:t.mdiCamera}})],1),e("input",{attrs:{type:"file",hidden:"",id:"file",name:"image"},on:{change:t.handleImageChange}})])]),e("button",{staticClass:"float-end p-2 bg-blue-400 shadow-md z-10 rounded-md",on:{click:t.handleAdd}},[t._v("Lưu")])])])]):t._e()},i=[],c=a(1394),n=a(7844),d=a(4373),l=a(2132),p={name:"AddProduct",props:["open","getproduct"],data(){return{percent:0,image:"",name:"",discounted:0,categoryId:"",price:0,description:"",listCategory:"",mdiClose:l.hyP,mdiCamera:l.KgF}},created(){this.getcategory()},methods:{close(){this.$emit("close")},remove(){this.image=""},async handleImageChange(t){const e=t.target.files[0];if(e)try{const t=(0,n.KR)(c.i,`/product/${e.name}`),a=(0,n.bp)(t,e);a.on("state_changed",(t=>{this.percent=Math.round(t.bytesTransferred/t.totalBytes*100)}),(t=>console.log(t)),(async()=>{const t=await(0,n.qk)(a.snapshot.ref);this.image=t}))}catch(a){console.error("Error uploading image:",a)}},async getcategory(){try{const t=await d.A.get("/Category/getAll");this.listCategory=t.data}catch(t){console.log(t)}},async handleAdd(){try{await d.A.post("/Product/create",{name:this.name,categoryId:this.categoryId,price:this.price,description:this.description,image:this.image,discounted:this.discounted}),this.getproduct(),this.$toast("Thêm thành công",{position:"top-right",timeout:5e3})}catch(t){console.log(t)}}}},u=p,m=a(1656),g=(0,m.A)(u,r,i,!1,null,null,null),h=g.exports,v=function(){var t=this,e=t._self._c;return t.open?e("div",{staticClass:"fixed flex items-center z-20 inset-0 bg-black bg-opacity-50 h-[100vh] w-full"},[e("div",{staticClass:"bg-white w-full mx-auto md:w-1/2"},[e("div",{staticClass:"text-center relative"},[e("h1",{staticClass:"uppercase font-bold text-xl bg-[#271511] text-white p-2"},[t._v("Sửa sản phẩm")]),e("div",{on:{click:t.close}},[e("VueIcon",{staticClass:"absolute top-0 right-0 hover:cursor-pointer text-white hover:bg-red-500",attrs:{type:"mdi",path:t.mdiClose,size:"30"}})],1)]),e("div",{staticClass:"flex flex-col gap-5 p-5"},[e("input",{directives:[{name:"model",rawName:"v-model",value:t.name,expression:"name"}],staticClass:"border-b w-full p-2",attrs:{type:"text",name:"name",placeholder:"Tên sản phẩm"},domProps:{value:t.name},on:{input:function(e){e.target.composing||(t.name=e.target.value)}}}),e("div",{staticClass:"flex gap-5"},[e("div",[e("label",{attrs:{for:"Price"}},[t._v("Giá")]),e("input",{directives:[{name:"model",rawName:"v-model",value:t.price,expression:"price"}],staticClass:"border-b w-full p-2",attrs:{type:"number",id:"Price",placeholder:"Giá"},domProps:{value:t.price},on:{input:function(e){e.target.composing||(t.price=e.target.value)}}})]),e("div",[e("label",{attrs:{for:"Discounted"}},[t._v("Ưu đãi %")]),e("input",{directives:[{name:"model",rawName:"v-model",value:t.discounted,expression:"discounted"}],staticClass:"border-b w-full p-2",attrs:{type:"number",id:"Discounted",placeholder:"Ưu đãi %"},domProps:{value:t.discounted},on:{input:function(e){e.target.composing||(t.discounted=e.target.value)}}})])]),e("textarea",{directives:[{name:"model",rawName:"v-model",value:t.description,expression:"description"}],staticClass:"border-b w-full p-2",attrs:{placeholder:"Mô tả"},domProps:{value:t.description},on:{input:function(e){e.target.composing||(t.description=e.target.value)}}}),t._v(" "),e("div",{staticClass:"flex gap-5"},[e("select",{directives:[{name:"model",rawName:"v-model",value:t.categoryId,expression:"categoryId"}],staticClass:"p-2 w-40 h-10 border outline-none",attrs:{name:"",id:""},on:{change:function(e){var a=Array.prototype.filter.call(e.target.options,(function(t){return t.selected})).map((function(t){var e="_value"in t?t._value:t.value;return e}));t.categoryId=e.target.multiple?a:a[0]}}},[e("option",{attrs:{value:"",selected:""}},[t._v("Danh mục")]),t._l(t.listCategory,(function(a){return e("option",{key:a.categoryId,domProps:{value:a.categoryId}},[t._v(t._s(a.name))])}))],2),e("div",{staticClass:"flex"},[t.image?e("div",{staticClass:"relative"},[e("img",{staticClass:"w-10 h-10 md:w-20 md:h-20 border-2 text-2xl block hover:cursor-pointer",attrs:{src:t.image,alt:""}}),e("div",{on:{click:t.remove}},[e("VueIcon",{staticClass:"absolute top-0 right-0 hover:cursor-pointer border bg-slate-100 rounded-[50%]",attrs:{type:"mdi",path:t.mdiClose,size:"20"}})],1)]):e("label",{staticClass:"w-10 h-10 md:w-20 md:h-20 border-2 flex justify-center items-center hover:cursor-pointer",attrs:{for:"file"}},[e("VueIcon",{attrs:{type:"mdi",path:t.mdiCamera}})],1),e("input",{attrs:{type:"file",hidden:"",id:"file",name:"image"},on:{change:t.handleImageChange}})])]),e("button",{staticClass:"float-end p-2 bg-blue-400 shadow-md z-10 rounded-md",on:{click:t.handleUpdate}},[t._v("Lưu")])])])]):t._e()},y=[],f={name:"AddProduct",props:["open","getproduct","productIdToUpdate"],data(){return{percent:0,image:"",name:"",discounted:0,categoryId:"",price:0,description:"",listCategory:"",mdiClose:l.hyP,mdiCamera:l.KgF}},mounted(){this.getcategory(),this.getProductById()},watch:{productIdToUpdate:function(){this.getProductById()}},methods:{close(){this.$emit("close")},remove(){this.image=""},async handleImageChange(t){const e=t.target.files[0];if(e)try{const t=(0,n.KR)(c.i,`/product/${e.name}`),a=(0,n.bp)(t,e);a.on("state_changed",(t=>{this.percent=Math.round(t.bytesTransferred/t.totalBytes*100)}),(t=>console.log(t)),(async()=>{const t=await(0,n.qk)(a.snapshot.ref);this.image=t}))}catch(a){console.error("Error uploading image:",a)}},async getcategory(){try{const t=await d.A.get("/Category/getAll");this.listCategory=t.data}catch(t){console.log(t)}},async getProductById(){try{const t=await d.A.get(`/Product/getOne/${this.productIdToUpdate}`);this.name=t.data.name,this.image=t.data.image,this.categoryId=t.data.category.categoryId,this.description=t.data.description,this.price=t.data.price,this.discounted=t.data.discounted}catch(t){console.log(t)}},async handleUpdate(){try{await d.A.patch(`/Product/update/${this.productIdToUpdate}`,{name:this.name,categoryId:this.categoryId,price:this.price,description:this.description,image:this.image,discounted:this.discounted}),this.close(),this.getproduct(),this.$toast("Sửa thành công",{position:"top-right",timeout:5e3})}catch(t){console.log(t)}}}},C=f,b=(0,m.A)(C,v,y,!1,null,null,null),w=b.exports,x={name:"ProductView",components:{AddProduct:h,EditProduct:w},props:["updateProduct"],data(){return{add:!1,update:!1,data:[],page:1,limit:100,productIdToUpdate:"",mdiTrashCanOutline:l.FhF,mdiEyedropperVariant:l.xeK,mdiChevronRight:l.mI8,mdiCogOutline:l.ED,mdiEyeOutline:l._r5,categorys:"",categoryId:""}},mounted(){this.getproduct(),this.getcategory()},watch:{categoryId:function(){""==this.categoryId?this.getproduct():this.filter()}},methods:{async getproduct(){try{const t=await d.A.get(`/product/getByPage?page=${this.page}&limit=${this.limit}`);this.data=t.data.products}catch(t){console.error(t)}},async handleDelete(t){const e=confirm("Bạn có chắc chắn muốn xóa không?");if(e)try{await d.A.delete(`product/delete/${t}`),this.getproduct(),this.$toast("Xóa thành công",{position:"top-right",timeout:5e3})}catch(a){console.log(a),this.$toast("Xóa không thành công",{position:"top-right",timeout:5e3})}},handleLoad(){this.getproduct()},handleAdd(){this.add=!0},handleUpdate(t){this.update=!0,this.productIdToUpdate=t},handleClose(){this.add=!1,this.update=!1},async prevPage(){this.page>1&&(this.page--,await this.getproduct())},async nextPage(){this.page++,await this.getproduct()},async getcategory(){try{const t=await d.A.get("/Category/getAll");this.categorys=t.data}catch(t){console.log(t)}},async filter(){try{const t=await d.A.get(`/Product/getByCategory/${this.categoryId}`);this.data=t.data.products}catch(t){console.log(t)}}}},_=x,I=(0,m.A)(_,s,o,!1,null,null,null),P=I.exports}}]);
//# sourceMappingURL=208.f47155a8.js.map