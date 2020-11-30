import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import PersonList from '../views/Persons/PersonList.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/persons',
    name: 'PersonList',
    component: PersonList,
    meta: {
      requiresAuth: true
    }
  },
  { 
    path: '/login',
    name: 'Login',
    component: () => import('../views/Login.vue')
  },
  {
    path: '/games',
    name: 'GameList',
    component: () => import('../views/Games/GameList.vue'),
    meta: {
      requiresAuth: true
    }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (sessionStorage.getItem('user') == null) {
      next({
        path: '/login',
        params: { nextUrl: to.fullPath }
      })
    } else {

      next()

    }
  } else {
    next()
  }
})


export default router
