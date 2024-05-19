import {defineStore} from "pinia";


export const  useMapStore = defineStore('useMapStore', {
    state: () => {
        return{
            points: [
                {
                    icon: 'pi-maps-marker',
                    coordinates: [83.779947, 53.344742],
                    color: '#ff4433',
                    title: '',
                    draggable: false
                },
                {
                    icon: 'pi-maps-marker',
                    coordinates: [ 83.789446, 53.360445],
                    color: '#ff4433',
                    title: '',
                    draggable: false
                },
                {
                    icon: 'pi-maps-marker',
                    coordinates: [ 83.772595, 53.330802 ],
                    color: '#ff4433',
                    title: '',
                    draggable: false
                },
                {
                    icon: 'pi-maps-marker',
                    coordinates: [  83.749296, 53.363854 ],
                    color: '#ff4433',
                    title: '',
                    draggable: false
                },
                {
                    icon: 'pi-maps-marker',
                    coordinates: [   83.730180, 53.338066 ],
                    color: '#ff4433',
                    title: '',
                    draggable: false
                }
            ],
            activePoint: undefined
        }
    },
    actions: {
        setActivePoint(point: any){
            this.activePoint = point
        },
        resetActivePoint(){
            this.activePoint = undefined
        }

    },
    getters: {

    }
})