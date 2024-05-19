<script setup lang="ts">


import {storeToRefs} from "pinia";
import {useMapStore} from "../../../store/useMapStore.ts";
import {ref} from "vue";

const {activePoint} =storeToRefs(useMapStore())

import avatar from '../../../assets/image/Avatar.png'
import avatar2 from '../../../assets/image/Avatar2.png'
import photo1 from '../../../assets/image/foto1.png'
import photo2 from '../../../assets/image/foto2.png'
import photo3 from '../../../assets/image/Foto.png'
import {useRouter} from "vue-router";

const images = ref([
  {
    itemImageSrc: photo1,
    thumbnailImageSrc: photo1,
    alt: 'Фото 1',
    title: 'Фото 1'
  },
  {
    itemImageSrc: photo2,
    thumbnailImageSrc: photo2,
    alt: 'Фото 1',
    title: 'Фото 1'
  },
  {
    itemImageSrc: photo3,
    thumbnailImageSrc: photo3,
    alt: 'Фото 1',
    title: 'Фото 1'
  },
])

const comments = ref([
  {
    name: 'Макс Ф.',
    text: 'Куча разных плюшек тут, впечатления бомбические, один минус - не успел найти минусы',
    rating: 5,
    avatar: avatar
  },
  {
    name: 'Алекс М.',
    text: 'Наверное лучшее место для фрилансера, переговоров и коференций',
    rating: 4,
    avatar: avatar2
  },
  {
    name: 'Виталий К.',
    text: 'Работаем с коллегами регулярно раз в неделю в этом коворкинге. Очень нравится атмосфера, отношение сотрудников, желание помочь,',
    rating: 5,
    avatar: avatar
  },
  {
    name: 'Екатерина М.'
  },
  {
    name: 'Наталья К.'
  }
])

const rating = ref(4.3)
defineEmits(['closeInformation'])

const router = useRouter()
</script>

<template>
  <div style="position: absolute;">
    <Button @click="$emit('closeInformation')" text rounded icon="pi pi-times" style="color: black;"></Button>
  </div>
  <div class="place-information">
    <div class="header" style="margin-right: 40px">
      <div class="name heading" style="font-size: 2rem; font-weight: 600">
        Бизнес-Центр
      </div>
      <div class="boss heading" style="font-size: 1.2rem; font-weight: 500; text-align: right;">
        ООО "Делу время"
      </div>
    </div>
    <div class="params">
      <div class="param">
        <div class="text">
          Барнаул, пр. Ленина, д.51
        </div>
        <div class="icon">
          <i class="pi pi-map-marker"></i>
        </div>
      </div>
      <div class="param">
        <div class="text">
          945 кв.м.
        </div>
        <div class="icon">
          <i class="pi pi-expand"></i>
        </div>
      </div>
      <div class="param">
        <div class="text">
          2 этаж
        </div>
        <div class="icon">

        </div>
      </div>
      <div class="param">
        <div class="text">
          25/76
        </div>
        <div class="icon">
          <i class="pi pi-table"></i>
        </div>
      </div>
      <div class="param">
        <div class="text">
          Построить маршрут
        </div>
        <div class="icon">
          <i class="pi pi-compass"></i>
        </div>
      </div>
      <div class="param">
        <div class="text">
          4.3
        </div>
        <div class="icon">
          <i class="pi pi-star"></i>
        </div>
      </div>
      <div class="param" style="grid-template-columns: 1fr;">
        <Button @click="router.push({path: '/login'})" style="height: 36px; width: 245px; background: #eec77e;color: #1a1a1a; font-weight: 600; text-align: center" label="Заказать" />
      </div>
    </div>
    <div class="gallery">
      <Carousel :value="images" :numVisible="2" style="width: 580px"
                :showThumbnails="false" :showIndicators="false" >
        <template #item="slotProps">
          <img :src="slotProps.data.itemImageSrc" height="207px" width="272px" :alt="slotProps.data.alt" style="width: 100%; display: block" />
        </template>
      </Carousel>
    </div>
    <div class="comment">
      <Carousel :value="comments" :numVisible="3" :showIndicators="false"  class="corusel-comments">
        <template #item="slotProps">
          <Card style="width: 250px; height: 160px; margin-left: 24px;">
            <template #title>
              <div class="header-card-comment">
                <div class="avatar">
                  <img :src="slotProps.data.avatar"/>
                </div>
                <div class="name" style="padding-left: 10px; font-size: 1.1rem;">
                  {{slotProps.data.name}}
                </div>
                <div class="star" style="padding-left: 10px; font-size: 1.3rem;">
                  <Rating v-model="slotProps.data.rating" readonly :cancel="false" />
                </div>
              </div>
            </template>
            <template #content>
              <p class="m-0">
                {{slotProps.data.text}}
              </p>
            </template>
          </Card>
        </template>
      </Carousel>

    </div>
  </div>
</template>

<style scoped>
.place-information{
  width: 100%;
  height: 100%;
  background: var(--secondary-light);
  border-radius: 1rem 0 0 1rem;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  align-items: flex-end;
}
.params{
  display: flex;
  flex-direction: column;
  gap: 10px
}
.param{
  height: 24px;
  width: 280px;
  display: grid;
  grid-template-columns: 4fr 1fr;
  font-size: 1.1rem;
  font-weight: 600;
}
.param .icon i {
  font-size: 1.1rem;
  font-weight: 600;
}
.comment{
  display: flex;
  gap: 10px
}
.header-card-comment{
  height: 36px;
  width: 100%;
  display: grid;
  grid-template-columns: 1fr 4fr;
  grid-template-rows: 1fr 1fr;
}
.avatar{
  grid-area: 1 / 1 / span 2 / span 1
}

.corusel-comments{
 width: 700px
}

@media  only screen and (max-width: 576px) {
  .corusel-comments{
    width: 600px
  }
}
</style>
