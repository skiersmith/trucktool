import Vue from 'vue'
import Router from 'vue-router'
import Register from '../components/Register'
import Home from '../components/Home'
import Account from '../components/Account'
import Keep from '../components/Keep'
import Vault from '../components/Vault'
import Good from '../components/Good'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/register',
      name: 'Register',
      component: Register
    },
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/account',
      name: 'Account',
      component: Account
    },
    {
      path: '/keep',
      name: 'Keep',
      component: Keep
    },
    {
      path: '/vault/:vaultId',
      name: 'Vault',
      component: Vault,
      props: true
    },
    {
      path: '/good',
      name: 'Good',
      component: Good,
    },
    
    
  ]
})
