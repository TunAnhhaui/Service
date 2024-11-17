<template>
    <div class="grid grid-cols-6 max-h-20 bg-yellow-200 rounded-lg">
        <div class="col-span-2 flex justify-center items-center w-full  relative overflow-hidden">
            <div class=" absolute w-4 h-4 rounded-full -top-2 -right-2 bg-white"></div>
            <div class=" absolute w-4 h-4 rounded-full -bottom-2 -right-2 bg-white"></div>
            <div class="rounded-md w-16 h-16">
                <img src="https://theme.hstatic.net/200000796751/1001266995/14/home_coupon_1_img.png?v=38" alt=""
                    class="w-full h-full object-fill">
            </div>
        </div>
        <div class="col-span-4 w-full relative overflow-hidden">
            <div class=" absolute w-4 h-4 rounded-full -top-2 -left-2 bg-white"></div>
            <div class=" absolute w-4 h-4 rounded-full -bottom-2 -left-2 bg-white"></div>
            <div class="px-3 flex flex-col">
                <div>
                    <p class="text-sm font-bold">{{ item.name }}</p>
                    <p class="text-xs">Giảm {{ item.discountRate }} % khi thanh toán</p>
                </div>
                <div class="flex justify-between items-center">
                    <p class="text-[10px]">
                        <span v-if="item.userPromotions.some(u => u.userId == $store.state.user.id)">
                            Đã sử dụng
                        </span>
                        <span v-else-if="timeRemaining.daysRemaining > 0">
                            Có hiệu lực sau {{ timeRemaining.daysRemaining }} ngày
                        </span>
                        <span v-else-if="timeRemaining.hoursRemaining >= 0">
                            Có hiệu lực sau {{ timeRemaining.hoursRemaining }} giờ
                        </span>
                        <span v-else-if="timeRemaining.isExpired">
                            Đã hết hiệu lực
                        </span>
                        <span v-else>
                            <p v-if="timeRemaining.endDate">Có hiệu lực đến {{ formatDate(timeRemaining.endDate) }}</p>
                            <p v-else>Có hiệu lực ngay bây giờ</p>
                        </span>
                    </p>
                    <div @click="copyToClipboard(item.code)" :class="[
                        item.isActive && !item.userPromotions.some(u => u.userId === $store.state.user.id) ? 'bg-blue-500 text-white cursor-pointer' : 'bg-gray-100 text-gray-500',
                        'text-xs p-1 rounded-md'
                    ]">
                        {{ voucherCode === item.code ? "Copied" : "Copy" }}
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import moment from 'moment';
export default {
    name: "VoucherItem",
    props: ["item"],
    data() {
        return {
            voucherCode: "",
        }
    },
    methods: {
        formatDate(dateString) {
            return moment(dateString).format('YYYY-MM-DD');
        },
        async copyToClipboard(text) {
            if (this.item.isActive && !this.item.userPromotions.some(u => u.userId === this.$store.state.user.id)) {
                await navigator.clipboard.writeText(text);
                this.voucherCode = text
                setTimeout(() => {
                    this.voucherCode = "";
                }, 3000);
            }
        },
    },
    computed: {
        timeRemaining() {
            const currentDate = new Date();
            const startDate = this.item.startDate;
            const endDate = this.item.endDate;
            const timeDifference = startDate - currentDate;

            const daysRemaining = Math.floor(timeDifference / (1000 * 60 * 60 * 24));
            const hoursRemaining = Math.floor((timeDifference % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            const isExpired = this.item.endDate ? currentDate >= endDate : false;
            return { daysRemaining, hoursRemaining, timeDifference, endDate, currentDate, isExpired };
        },
    }
}
</script>