import axios from 'axios'
import vue from 'vue'
import vuex from 'vuex'
import router from '../router'
import { loadavg } from 'os';


let api = axios.create({
    baseURL: '//localhost:5000/api/',
    timeout: 2000,
    withCredentials: true
})

let auth = axios.create({
    baseURL: '//localhost:5000/',
    timeout: 2000,
    withCredentials: true
})
vue.use(vuex)

var store = new vuex.Store({
    state: {

        error: {},
        user: {},
        activeKeeps: {},
        activeVaults: {},
        activeKeep: {},
        myKeeps: {
            // keep: {
            //     decsription: "jig0rajij",
            //     url: "hgursibngijs"
            // }
        },
        activeVaultKeep:{}
    },
    mutations: {
        setUser(state, data) {
            console.log("setting user")
            state.user = data
        },
        setActiveKeeps(state, data) {

            state.activeKeeps = data
        },
        setActiveKeep(state, data) {

            state.activeKeep = data
        },

        handleError(state, err) {
            state.error = err
        },
        setMyKeeps(state, data) {
            state.myKeeps = date
        },
        setActiveVaults(state, data) {
            console.log("AV")
            console.log(data)
            state.activeVaults = data

        },
        setVaultKeep(state, data) {
          console.log("hi")
            state.activeVaultKeep = data

        },

    },
    actions: {
        addToVault({ commit, dispatch }, vault) {
        var v = {
            VaultId: vault.vaultId,
            KeepId:  vault.keepId
        }
            api.post('vaultkeeps', v)
                .then(res => {
                    console.log("res")
                    console.log(res.data)

                    dispatch('getUserVaults', res.data.userId)

                })
                .catch(err => {
                    commit('handleError', err)

                })
        },        //---------VAULTS-----------//
        newVault({ commit, dispatch }, vault) {
            api.post('vaults', vault)
                .then(res => {
                    console.log(res.data)

                    dispatch('getUserVaults', res.data.userId)

                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        getUserVaults({ commit, dispatch }, userId) {
            api('vaults/users/' + userId)
                .then(res => {
                    console.log("^><^><")
                    console.log(res.data)
                    console.log("^><^><")
                    commit('setActiveVaults', res.data)


                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        getKeepsAtVault({ commit, dispatch }, VaultId) {
            api('vaultkeeps/' + VaultId)
                .then(res => {
                    console.log(res.data)
                    commit('setVaultKeep', res.data)


                })
                .catch(err => {
                    commit('handleError', err)

                })
        },

        //---------KEEPS-----------//

        newKeep({ commit, dispatch }, keep) {
            api.post('keeps', keep)
                .then(res => {
                    console.log(res.data)

                    dispatch('getAllKeeps')

                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        getAllKeeps({ commit, dispatch }, keep) {
            api('keeps')
                .then(res => {
                    console.log(res.data)
                    commit('setActiveKeeps', res.data)


                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        deleteKeep({ commit, dispatch }, keep) {
            api.delete('keeps/' + keep.id)
                .then(res => {
                    console.log("gjireojgeiojgioejj")
                    console.log(res.data)
                    dispatch('getAllKeeps')


                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        //---------LOGIN/REGISTER/LOGOUT-----------//

        updateUser({ commit, dispatch }, user) {
            auth.put('accounts', user)
                .then(res => {
                    console.log(res.data)
                    commit('setUser', res.data)
                    // router.push({ name: 'Home' })
                    dispatch('authenticate')

                })
                .catch(err => {
                    commit('handleError', err)
                    router.push({ name: "Register" })
                })
        },

        updateUserPassword({ commit, dispatch }, user) {
            auth.put('accounts/change-password', user)
                .then(res => {
                    console.log(res.data)
                    commit('setUser', res.data)
                    // router.push({ name: 'Home' })
                    dispatch('authenticate')

                })
                .catch(err => {
                    commit('handleError', err)
                    router.push({ name: "Register" })
                })
        },
        userLogin({ commit, dispatch }, login) {
            auth.post('accounts/login', login)
                .then(res => {

                    console.log("user\/")
                    console.log(res.data)
                    commit('setUser', res.data)
                    router.push({ name: 'Home' })
                    dispatch('authenticate')

                })
                .catch(err => {
                    commit('handleError', err)
                    router.push({ name: "Register" })
                })
        },
        userRegister({ commit, dispatch }, register) {
            auth.post('accounts/register', register)
                .then(res => {
                    console.log(register)
                    console.log(res)

                    commit('setUser', res.data)
                    dispatch('authenticate')
                })
                .catch(err => {
                    commit('handleError', err)
                    router.push({ name: "Register" })
                })
        },
        authenticate({ commit, dispatch }) {
            auth('accounts/authenticate')
                .then(res => {
                    console.log("authRes")
                    console.log(res)
                    if (!res.data) {
                        router.push({ name: "Register" })
                    } else {
                        commit('setUser', res.data)
                    }
                })
                .catch(() => {
                    router.push({ name: "Register" })
                })
        },
        logout({ commit, dispatch }, user) {
            auth.delete('accounts/logout', user)
                .then(res => {
                    console.log("yooooo2")
                    router.push({ name: "Home" })
                })
                .catch(err => {
                    console.log(err)
                    res.status(401).send({ Error: err })
                })
        },
        //^^^^^^^^^^^^^^USER/REGISTER/LOGOUT^^^^^^^^^^^//

        handleError({ commit, dispatch }, err) {
            commit('handleError', err)
        }
    }
})
export default store