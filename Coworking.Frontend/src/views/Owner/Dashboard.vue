<script setup lang="ts">

import PageHeader from "../../components/Page/PageHeader.vue";
import ChartStat from "../../components/ChartStat.vue";
</script>

<template>
  <PageHeader>
    <template #header>
      <div>
        <div class="name heading" style="font-size: 2rem; font-weight: 600; padding-left: 10px;">
          Бизнес-Центр
        </div>
      </div>
    </template>
    <template #content>
      <div>
        <ChartStat />
      </div>
    </template>
  </PageHeader>
</template>

<style scoped>

</style>