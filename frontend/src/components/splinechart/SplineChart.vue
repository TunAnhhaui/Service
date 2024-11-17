<template>
  <div class="w-full">
    <apexChart v-if="isDataReady" type="line" height="300" class="w-full" :options="chartOptions" :series="series" />
  </div>
</template>

<script>
export default {
  name: "SplineChart",
  props: ['categories', 'revenueByMonth'],
  data() {
    return {
      isDataReady: false,
      chartOptions: {
        chart: {
          id: 'line_chart',
        },
        xaxis: {
          categories: [],
        },
        title: {
          text: "Doanh thu (triệu VND)",
          align: "center",
          margin: 20,
          style: {
            fontSize: "18px",
            fontWeight: "bold",
            color: "#333",
          },
        },
      },
      series: [{
        name: 'Doanh thu',
        data: [],
      }],
    };
  },
  watch: {
    categories(newVal) {
      this.updateCategories(newVal);
    },
    revenueByMonth(newVal) {
      this.updateSeries(newVal);
    }
  },
  methods: {
    updateCategories(newCategories) {
      this.chartOptions = {
        ...this.chartOptions,
        xaxis: { categories: newCategories }
      };
      this.checkDataReady();
    },
    updateSeries(newSeriesData) {
      this.series = [{ name: 'Doanh thu', data: newSeriesData }];
      this.checkDataReady();
    },
    checkDataReady() {
      if (this.categories.length && this.revenueByMonth.length) {
        this.isDataReady = true;
      }
    }
  },
  mounted() {
    this.updateCategories(this.categories);
    this.updateSeries(this.revenueByMonth);
  }
};
</script>
