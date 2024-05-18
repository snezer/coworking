<script setup lang="ts">

</script>

<template>
  <g>
    <node
        v-for="node in nodeElementsByFloor"
        :data="node"
        :key="node.id"
    />
    {{nodeElements}}
  </g>
</template>

<style scoped>

</style>