<script setup lang="ts">
import {ref} from 'vue'
const lineData = ref( {
  labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
    {
      label: 'First Dataset',
      data: [65, 59, 80, 81, 56, 55, 40],
      fill: false,
      backgroundColor: '#2f4860',
      borderColor: '#2f4860',
      tension: .4
    },
    {
      label: 'Second Dataset',
      data: [28, 48, 40, 19, 86, 27, 90],
      fill: false,
      backgroundColor: '#00bb7e',
      borderColor: '#00bb7e',
      tension: .4
    }
  ]
})

const pieData =( {
  labels: ['A', 'B', 'C'],
      datasets: [
    {
      data: [300, 50, 100],
      backgroundColor: [
        "#FF6384",
        "#36A2EB",
        "#FFCE56"
      ],
      hoverBackgroundColor: [
        "#FF6384",
        "#36A2EB",
        "#FFCE56"
      ]
    }
  ]
})

const polarData = ref( {
  datasets: [{
    data: [
      11,
      16,
      7,
      3,
      14
    ],
    backgroundColor: [
      "#FF6384",
      "#4BC0C0",
      "#FFCE56",
      "#E7E9ED",
      "#36A2EB"
    ],
    label: 'My dataset'
  }],
      labels: [
    "Red",
    "Green",
    "Yellow",
    "Grey",
    "Blue"
  ]
})

const barData = ref( {
  labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
    {
      label: 'My First dataset',
      backgroundColor: '#2f4860',
      data: [65, 59, 80, 81, 56, 55, 40]
    },
    {
      label: 'My Second dataset',
      backgroundColor: '#00bb7e',
      data: [28, 48, 40, 19, 86, 27, 90]
    }
  ]
})
const radarData = ref( {
  labels: ['Eating', 'Drinking', 'Sleeping', 'Designing', 'Coding', 'Cycling', 'Running'],
      datasets: [
    {
      label: 'My First dataset',
      backgroundColor: 'rgba(179,181,198,0.2)',
      borderColor: 'rgba(179,181,198,1)',
      pointBackgroundColor: 'rgba(179,181,198,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(179,181,198,1)',
      data: [65, 59, 90, 81, 56, 55, 40]
    },
    {
      label: 'My Second dataset',
      backgroundColor: 'rgba(255,99,132,0.2)',
      borderColor: 'rgba(255,99,132,1)',
      pointBackgroundColor: 'rgba(255,99,132,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(255,99,132,1)',
      data: [28, 48, 40, 19, 96, 27, 100]
    }
  ]
})
    const lineOptions = ref( null)

    const pieOptions = ref( null)

    const polarOptions = ref( null)

    const barOptions = ref( null)

    const radarOptions = ref( null)
</script>

<template>
  <div>
    <div class="grid p-fluid">
      <div class="col-12 col-6">
        <div class="card">
          <h5>Linear Chart</h5>
          <Chart type="line" :data="lineData" :options="lineOptions" />
        </div>

        <div class="card flex flex-column align-items-center">
          <h5 class="align-self-start">Pie Chart</h5>
          <Chart type="pie" :data="pieData" :options="pieOptions" style="width: 50%" />
        </div>

        <div class="card  flex flex-column align-items-center">
          <h5 class="align-self-start">Polar Area Chart</h5>
          <Chart type="polarArea" :data="polarData" :options="polarOptions" style="width: 50%" />
        </div>
      </div>
      <div class="col-12 col-6">
        <div class="card">
          <h5>Bar Chart</h5>
          <Chart type="bar" :data="barData" :options="barOptions" />
        </div>

        <div class="card flex flex-column align-items-center">
          <h5 class="align-self-start">Doughnut Chart</h5>
          <Chart type="doughnut" :data="pieData" :options="pieOptions" style="width: 50%" />
        </div>

        <div class="card flex flex-column align-items-center">
          <h5 class="align-self-start">Radar Chart</h5>
          <Chart type="radar" :data="radarData" :options="radarOptions" style="width: 50%" />
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>

</style>