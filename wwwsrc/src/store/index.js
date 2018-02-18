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
        activeRecords: {
            record: {
                Dot: "9985564"

            }
        },
        activeVaults: {},
        activeYTransactions: {},
        activeOTransactions: {},
        activeGTransactions: {},
        myKeeps: {
            // keep: {
            //     decsription: "jig0rajij",
            //     url: "hgursibngijs"
            // }
        },
        activeVaultKeep: {},
        activeSTD: {}
    },
    mutations: {
        setUser(state, data) {

            state.user = data
        },
        setActiveRecords(state, data) {
            state.activeRecords = data
        },
        setActiveOTransactions(state, data) {
            console.log("heere")

            state.activeOTransactions = data
        },
        setActiveYTransactions(state, data) {
            state.activeYTransactions = data
        },
        setActiveGTransactions(state, data) {
            state.activeGTransactions = data
            console.log("heere")

        },
        setMyKeeps(state, data) {

            state.myKeeps = data

        },

        handleError(state, err) {
            state.error = err
        },

        setActiveVaults(state, data) {

            state.activeVaults = data

        },
        setVaultKeep(state, data) {
            state.activeVaultKeep = data

        },
        setActiveSTD(state, data) {
            state.activeSTD = data

        },
        clearSTD(state, data) {
            state.activeYTransactions = data
            state.activeOTransactions = data
        }

    },
    actions: {
        searchTransByDot({ commit, dispatch }, dot) {
            api('transactions/' + dot)
                .then(res => {
                   console.log(res.data)
                    if(res.data != []){
                        // res.data = [res.data]
                        console.log("this is why I'm broken")
                    }
                    console.log(res.data)
                    debugger
                    var yellow = []
                    var orange = []
                    var green = []
                    for (let i = 0; i < res.data.length; i++) {
                        console.log("hers")
                        var element = res.data[i];
                        if (element.status == "yellow") {
                            yellow.push(element)
                            console.log("hers")
                            continue
                        }
                        else if (element.status == "orange") {
                            orange.push(element)
                            console.log("hers")
                            continue
                        }
                        else if (element.status == "green") {
                            // commit('setOTransaction')
                            green.push(element)
                        }
                        else { }
                    }
                    var data1 = {}
                    commit('clearSTD', data1)
                    commit('setActiveYTransactions', yellow)
                    commit('setActiveOTransactions', orange)
                    commit('setActiveGTransactions', green)

                    // else{
                    //     var data1 = [res.data]
                    //     if (res.data.status == "yellow") {
                    //         commit('setActiveYTransactions', data1)
                    //     }
                    //     else if (res.data.status == "orange") {
                    //         commit('setActiveOTransactions', data1)
                    //     }
                    // }
                })

                .catch(err => {
                    commit('handleError', err)

                })
        },

        deleteVK({ commit, dispatch }, keep) {

            api.delete('vaultkeeps/' + 'vaults/' + keep.vaultId + '/keeps/' + keep.id, )
                .then(res => {


                    dispatch('getUserVaults', res.data.userId)

                })
                .catch(err => {
                    commit('handleError', err)

                })
        },

        addToVault({ commit, dispatch }, vault) {
            var v = {
                VaultId: vault.vaultId,
                KeepId: vault.keepId
            }
            api.post('vaultkeeps', v)
                .then(res => {


                    dispatch('getUserVaults', res.data.userId)

                })
                .catch(err => {
                    commit('handleError', err)

                })
        },        //---------VAULTS-----------//
        newTransaction({ commit, dispatch }, transaction) {
            api.post('transactions', transaction)
                .then(res => {
                    dispatch('newRecordTransaction', res.data)
                    dispatch('searchTransByDot', res.data.dot)
                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        newRecordTransaction({ commit, dispatch }, transaction) {
            api.post('recordtransactions', transaction)
                .then(res => {
                    debugger
                    if(res.status == "red"){
                        dispatch('getRecord', transaction)
                    }
                    // dispatch('newRecordTransaction', res.data.userId)
                    
                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        // must get record id before userrecord can be deleted
        getRecord({ commit, dispatch }, transaction) {
            api('records', transaction)
                .then(res => {
                    debugger
                    if(res.status == "red"){
                        dispatch('deleteUserRecord', transaction)
                    }
                    // dispatch('newRecordTransaction', res.data.userId)
                    
                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        getUserVaults({ commit, dispatch }, userId) {
            api('vaults/users/' + userId)
                .then(res => {

                    commit('setActiveVaults', res.data)


                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        getKeepsAtVault({ commit, dispatch }, VaultId) {
            api('vaultkeeps/' + VaultId)
                .then(res => {

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


                    dispatch('authenticate2')


                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        getAllKeeps({ commit, dispatch }, keep) {
            api('keeps')
                .then(res => {

                    commit('setActiveKeeps', res.data)


                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        getUserRecords({ commit, dispatch }, userId) {

            api('userrecords/' + userId)
                .then(res => {

                    commit('setActiveRecords', res.data)
                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        deleteUserRecord({ commit, dispatch }, payload) {
            
            api.delete('userrecords/users/' + payload.userId + '/records/' + payload.recordId)
                .then(res => {

                    dispatch('getUserRecords', res.data)
                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        getUserTransactions({ commit, dispatch }, userId) {

            api('transactions/users/' + userId)
                .then(res => {
                    var yellow = []
                    var orange = []
                    var green = []
                    debugger
                    for (let i = 0; i < res.data.length; i++) {

                        var element = res.data[i];
                        if (element.status == "yellow") {
                            yellow.push(element)
                            continue
                        }
                        else if (element.status == "orange") {
                            orange.push(element)
                            continue
                        }
                        else if (element.status == "green") {
                            // commit('setOTransaction')
                            green.push(element)
                        }
                        else { }
                    }
                    commit('setActiveYTransactions', yellow)
                    commit('setActiveOTransactions', orange)
                    commit('setActiveGTransactions', green)
                })
                .catch(err => {
                    commit('handleError', err)

                })
        },

        deleteKeep({ commit, dispatch }, keep) {
            api.delete('keeps/' + keep.id)
                .then(res => {

                    dispatch('getMyKeeps', keep.userId)


                })
                .catch(err => {
                    commit('handleError', err)

                })
        },
        //---------LOGIN/REGISTER/LOGOUT-----------//

        updateUser({ commit, dispatch }, user) {
            auth.put('accounts', user)
                .then(res => {

                    commit('setUser', res.data)
                    // router.push({ name: 'Home' })
                    dispatch('authenticate')

                })
                .catch(err => {
                    commit('handleError', err)
                    // router.push({ name: "Register" })
                })
        },

        updateUserPassword({ commit, dispatch }, user) {
            auth.put('accounts/change-password', user)
                .then(res => {

                    commit('setUser', res.data)
                    // router.push({ name: 'Home' })
                    dispatch('authenticate')

                })
                .catch(err => {
                    commit('handleError', err)
                    // router.push({ name: "Register" })
                })
        },
        userLogin({ commit, dispatch }, login) {
            auth.post('accounts/login', login)
                .then(res => {
                    if (res.data = "") {
                    }


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


                    commit('setUser', res.data)
                    router.push({ name: 'Home' })
                })
                .catch(err => {
                    commit('handleError', err)
                    router.push({ name: "Register" })
                })
        },
        authenticate({ commit, dispatch }) {
            auth('accounts/authenticate')
                .then(res => {

                    if (!res.data) {
                        // router.push({ name: "Register" })
                    } else {
                        commit('setUser', res.data)
                        // dispatch('getUserVaults', res.data.id)
                    }
                })
                .catch(() => {
                    router.push({ name: "Register" })
                })
        },
        authenticate2({ commit, dispatch }) {
            auth('accounts/authenticate')
                .then(res => {

                    if (!res.data) {
                        // router.push({ name: "Register" })
                    } else {
                        commit('setUser', res.data)
                        // dispatch('getUserVaults', res.data.id)
                        // dispatch('getMyKeeps', res.data.id)
                    }
                })
                .catch(() => {
                    router.push({ name: "Register" })
                })
        },
        logout({ commit, dispatch }, user) {
            auth.delete('accounts/logout', user)
                .then(res => {

                    router.push({ name: "Register" })
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