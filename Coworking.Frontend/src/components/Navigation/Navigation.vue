<script setup lang="ts">

import {ref} from "vue";

defineProps({
  typeMenu: {
    type: String,
    default: 'owner'
  }
})

const itemsOwner = ref([
  {
    title: 'Главная',
    path: '/dashboard/main',
    icon: 'pi-home'
  },
  {
    title: 'Карта офиса',
    path: '/dashboard/editor',
    icon: 'pi-map'
  },
  {
    title: 'Календарь',
    path: '/dashboard/calendar',
    icon: 'pi-calendar'
  },
  {
    title: 'Задачи',
    path: '/dashboard/tasks',
    icon: 'pi-check-square'
  },
  {
    title: 'Помощь',
    path: '/dashboard/help',
    icon: 'pi-info-circle'
  },
])
</script>

<template>
  <div class="navigation-wrapper">
    <div class="header">

    </div>
    <div class="main">
      <div class="navigation items">
        <router-link
            class="item"
            v-for="item in itemsOwner"
            :to="item.path"
            active-class="active"
            :key="item.path"
        >
              <div class="icon">
                <i :class="`pi ${item.icon}`"></i>
              </div>
              <div>
                {{item.title}}
              </div>
        </router-link>
      </div>

    </div>
    <div class="footer">

    </div>
  </div>
</template>

<style scoped>
.navigation-wrapper{
  width: 100%;
  height: 100%;
  display: grid;
  grid-template-rows: 2fr 9fr 1fr;
  background: var(--secondary-light);
}
.main{
  padding: 24px;
}
navigation.items{
  display: flex;
  flex-direction: column;
  gap: 20px;
}
.item{
  height: 42px;
  display: grid;
  grid-template-columns: 2fr 10fr;
  color: var(--text-gray);
  text-decoration: none;
  font-weight: 500;
  font-size: 1.5rem;
}
.item i{
  font-size: 1.5rem;
}
.item.active{
  font-weight: 600;
  color: var(--text-blue-dark);
}
</style>