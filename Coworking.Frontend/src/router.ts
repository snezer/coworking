import { createRouter, createWebHistory} from 'vue-router'
import MainPage from "./views/MainPage.vue";
import Editor from "./views/Owner/Editor.vue";
import Login from "./views/Login.vue";
import MainPageOwner from "./views/Owner/MainPageOwner.vue";
import Dashboard from "./views/Owner/Dashboard.vue";
import UserMap from "./views/UserMap.vue";


const routes = [
    {
        path: '/',
        component: MainPage
    },
    {
        path: '/editor',
        component: Editor
    },
    {
        path: '/login',
        component: Login
    },
    {
        path: '/usermap',
        component: UserMap
    },
    {
        path: '/dashboard',
        component: MainPageOwner,
        children: [
            {
                path: 'main',
                components: {
                    default: MainPageOwner,
                    owner: Dashboard
                }
            },
            {
                path: 'editor',
                components: {
                    default: MainPageOwner,
                    owner: Editor
                }
            }
        ]
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export const LoadLoginPage  = async  () => {
    await router.push({path: '/login'})
}

export default router
