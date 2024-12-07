<template>
  <div class="w-full">
    <apexChart :key="chartKey" type="bar" height="350" :options="chartOptions" :series="series"></apexChart>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: "BarChart",
  data() {
    return {
      chartKey: 0,
      products: [],
      series: [{
        name: 'Số lượng đã bán',
        data: []
      }],
      chartOptions: {
        chart: {
          type: 'bar',
          height: 350
        },
        plotOptions: {
          bar: {
            borderRadius: 4,
            borderRadiusApplication: 'end',
            horizontal: true,
          }
        },
        title: {
          text: "Biểu đồ sản phẩm bán chạy",
          align: "center",
          style: {
            fontSize: "20px",
            fontWeight: "bold",
            color: "#263238", // Màu sắc của tiêu đề
          },
        },
        dataLabels: {
          enabled: false
        },
        xaxis: {
          categories: [],
        }
      },
    };
  },
  mounted() {
    this.getProductBySell()
  },
  methods: {
    async getProductBySell() {
      try {
        const res = await axios.get('/Product/sell')
        this.products = res.data
        console.log(res.data)
        this.series[0].data = res.data.map(p => p.sell)
        this.$set(this.chartOptions.xaxis, 'categories', res.data.map((p) => p.name));
        this.chartKey += 1;
      } catch (err) {
        console.log(err)
      }
    },
  }
};
</script>