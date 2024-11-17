<template>
     <div class="flex flex-col">
        <div class="flex flex-wrap gap-2 items-center text-xs md:text-sm px-5 md:px-10 py-2 bg-gray-100 text-gray-500">
            <router-link :to="{name:'home'}">Trang chủ </router-link>/<p class="line-clamp-1">Giỏ hàng ({{ countCart }})</p>
        </div>
        <div class="flex flex-col gap-5 p-5 md:p-10 dark:bg-black dark:text-white">
            <h1 class="text-center font-bold text-base md:text-3xl"><u>Giỏ hàng của bạn</u></h1>
            <div class="flex flex-col md:grid grid-cols-12 gap-5">
                <div class="col-span-8">
                    <div class="bg-gray-100 p-2 dark:text-black">Có <b>{{ countCart }} sản phẩm</b> trong giỏ hàng</div>
                    <div class="flex flex-col mt-5">
                        <div v-if="$store.state.user">
                            <table class="w-full border table">
                                <thead class="w-full text-gray-600 dark:text-white border">
                                    <tr class="w-full hidden lg:table-row text-xs lg:text-base font-bold">
                                        <th class="p-2 text-left">THÔNG TIN SẢN PHẨM</th>
                                        <th class="p-2 text-left">ĐƠN GIÁ</th>
                                        <th class="p-2 text-left">SỐ LƯỢNG</th>
                                        <th class="p-2 text-left">THÀNH TIỀN</th>
                                    </tr>
                                </thead>
                                <tbody v-if="countCart>0">
                                    <CartItem v-for="item in carts" :key="item.cartId" :item="item" :getCart="getCart"/>
                                </tbody>
                                <div v-else class=" p-2">Giỏ hàng của bạn trống</div>
                            </table>
                        </div>
                        <div v-else class="text-center p-2">Bạn chưa đăng nhập</div>
                    </div>
                </div>
                <div class="col-span-4">
                    <div class="flex flex-col gap-2">
                        <div class="flex flex-col gap-2 font-bold border p-2">
                            <h1 class="font-bold text-xl border-b py-2">Thông tin đơn hàng</h1>
                            <div class="flex justify-between py-2 border-b">
                                <p>Tổng tiền:</p>
                                <p class="text-red-500">{{ totalAmount | numeral }} <u>đ</u></p>
                            </div>
                            <router-link :to="{name:'checkout'}" class="uppercase bg-red-500 text-white font-bold p-2 text-center">Thanh toán</router-link>
                        </div>
                        <router-link :to="{name:'home'}" class="flex items-center gap-2 justify-center">
                            <VueIcon type="mdi" :path="mdiReply"/>
                            <p>Tiếp tục mua hàng</p>
                        </router-link>
                        <div class="flex flex-col text-gray-600 text-sm gap-2">
                            <p class="">
                                (+) <strong>Không rủi ro. Đặt hàng trước, thanh toán sau tại nhà. Miễn phí giao hàng & lắp đặt</strong>
                                tại tất cả quận huyện thuộc TP.HCM, Hà Nội, Khu đô thị Ecopark, Biên Hòa và một số khu vực thuộc Bình Dương (*)
                            </p>
                            <p class="">
                                (+) Đơn hàng của quý khách sẽ được
                                <strong>giao hàng trong vòng 3 ngày,</strong>
                                vui lòng đợi nhân viên tư vấn xác nhận lịch giao hàng trước khi thực hiện chuyển khoản đơn hàng                            
                            </p>
                            <p class="">
                                (+) <strong>Miễn phí 1 đổi 1 - Bảo hành 2 năm - Bảo trì trọn đời</strong> (**)
                            </p>
                            <p class="">
                                (+) Tất cả sản phẩm được thiết kế bởi các chuyên gia thiết kế nội thất đến từ 
                                 <strong>Đan Mạch và Hàn Quốc</strong>
                            </p>
                            <p class="">
                                (+) <strong>Chất lượng Quốc Tế đảm bảo theo tiêu chuẩn</strong>
                                cho người dùng tại Việt Nam
                            </p>
                            <p class="">
                                (+) Sản xuất tại nhà máy SAVIMEX với gần
                                <strong>40 năm kinh nghiệm</strong>
                            </p>
                            <p class="">(*) Không áp dụng cho danh mục Đồ Trang Trí</p>
                            <p>(**) Không áp dụng cho các sản phẩm Clearance. Chỉ bảo hành 01 năm cho khung ghế, mâm và cần đối với Ghế Văn Phòng</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
     </div>
</template>

<script>
import CartItem from '@/components/cartItem/CartItem.vue';
import { mdiReply,mdiCheckBold } from '@mdi/js';
export default {
    name:"CartView",
    props:["countCart","getCart","carts","totalAmount"],
    components:{CartItem},
    data(){
        return{
            mdiReply,mdiCheckBold
        }
    }
}
</script>