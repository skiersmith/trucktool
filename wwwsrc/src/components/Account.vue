<template>
    <div>
        <div class="nav-header">
            <div class="nav-header-container">

                <div>
                    <div class="nav-header-sub">
                        <router-link class="RLwhite headDown3" :to="{name: 'Home'}">
                            <h1>KEEPr</h1>
                        </router-link>
                    </div>
                </div>

                <div>
                </div>
                <div>
                    <div class="nav-header-sub">
                        <span @click="userLogout">
                            <p class="white">Logout</p>
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class="buttonDiv">
            <button@click="toggleKeepForm" class="btn btn-info">New Keep</button>
            <button@click="toggleVaultForm" class="btn btn-info">New Vault</button>
        </div>
        <div v-if="keepForm" class="bgColor">
            <form @submit.prevent="newKeep">
                <div class="form-group">

                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="imgurl">Img Url:</label>
                        <div class="col-sm-3 regInput">
                            <input type="url" size="40" name="imgurl" v-model="keep.imgUrl" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="description">Description:</label>
                        <div class="col-sm-3 regInput">
                            <input type="text" size="40" name="description" placeholder="Description" v-model="keep.description" />
                        </div>
                    </div>
                    <!-- <div class="form-group">
                        <label class="col-sm-2 control-label" for="url">Url:</label>
                        <div class="col-sm-3 regInput">
                            <input type="url" size="40" name="url" placeholder="url" v-model="keep.url" />
                        </div>
                    </div> -->
                    <div class="form-group">
                        <button type="submit">Submit</button>
                    </div>
                </div>
            </form>
        </div>
        <div class="spacer10"></div>
        <div class="brown">

            <div>
                <p>{{user.id}}</p>
                <p>{{user.username}}</p>
                <p>{{user.email}}</p>
            </div>
            <button@click="toggleUpdate">Update</button>
                <button@click="toggleUpdateB">UpdatePassword</button>
                    <div v-if="updateA">
                        <form @submit.prevent="updateUser">
                            <div class="form-group">
                                <br>
                                <div class="form-group">
                                    <button type="submit" class="btn-xs btn-success">Save</button>
                                </div>
                                <div class="form-group">
                                    <label for="name">Name</label>
                                    <input class="inline" size="15" type="text" name="name" placeholder="name" v-model="user.username">
                                </div>
                                <div class="form-group">
                                    <label for="resalePrice">Email</label>
                                    <input class="inline" size="15" type="text" name="email@email.com" placeholder="resalePrice" v-model="user.email">
                                </div>
                            </div>
                        </form>
                    </div>
                    <div v-if="updateB">
                        <form @submit.prevent="updateUserPassword">
                            <div class="form-group">
                                <br>
                                <div class="form-group">
                                    <button type="submit" class="btn-xs btn-success">Save</button>
                                </div>
                                <div class="form-group">
                                    <label for="name"> Old Password</label>
                                    <input class="inline" size="15" type="password" name="password" placeholder="Password" v-model="user.OldPassword">
                                </div>
                                <div class="form-group">
                                    <label for="name">New Password</label>
                                    <input class="inline" size="15" type="password" name="password" placeholder="Password" v-model="user.NewPassword">
                                </div>

                            </div>
                        </form>
                    </div>
        </div>


        <div v-if="vaultForm">
            <form @submit.prevent="newVault">
                <div class="form-group">

                    <!-- <div class="form-group">
                        <label class="col-sm-2 control-label" for="inputName">Name:</label>
                        <div class="col-sm-3 regInput">
                            <input type="text" size="40" id="inputName" placeholder="Name" v-model="keep.username" />
                        </div>
                    </div> -->
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="description">Name:</label>
                        <div class="col-sm-3 regInput">
                            <input type="text" size="40" name="name" placeholder="name" v-model="vault.name" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="url">Description:</label>
                        <div class="col-sm-3 regInput">
                            <input type="text" size="40" name="description" placeholder="description" v-model="vault.description" />
                        </div>
                    </div>
                    <div>
                        <button type="submit">Submit</button>
                    </div>
                </div>
            </form>
        </div>


        <!-- <vault></vault> -->
        <h1>Vaults</h1>
        <div v-for="vault in vaults">
            <router-link :to="{name: 'Vault', params: { vaultId: vault.id, vault: vault }}">
                <p>{{vault.name}}</p>
            </router-link>
        </div>


        <div v-for="keep in keeps">
            <div class="col-xl-4 col-xs-6 mainDiv">
                <!-- @click="setKeep(keep)" -->
                <div>
                    <img class="keepImg" :src="keep.imgUrl" alt="keep image">
                </div>
                <div>
                    <!-- <p>{{keep.imgUrl}}</p> -->
                    <p>
                        {{keep.description}}
                    </p>
                </div>
                <div class="keepStat-Container">
                    <p>{{keep.views}}</p>
                    <p>{{keep.keeps}}</p>
                </div>
            </div>
        </div>

    </div>
</template>
<script>
    import vault from './Vault'
    export default {
        name: 'Account',
        data() {
            return {
                keep: {},
                vault: {},
                updateA: false,
                updateB: false,
                vaultForm: false,
                keepForm: false,
            }
        },
        methods: {
            userLogout() {
                this.$store.dispatch('logout', this.$store.state.user._id)
            },
            toggleUpdate() {
                this.updateA = !this.updateA
            },
            toggleUpdateB() {
                this.updateB = !this.updateB
            },
            toggleVaultForm() {
                this.vaultForm = !this.vaultForm
            },
            updateUser() {
                this.$store.dispatch('updateUser', this.user)
            },
            updateUserPassword() {
                console.log("yooo" + this.user.password)
                this.$store.dispatch('updateUserPassword', this.user)
            },
            newVault() {

                this.$store.dispatch('authenticate')
                this.$store.dispatch('newVault', this.vault)
            },
            toggleKeepForm() {
                this.keepForm = !this.keepForm
            },
            newKeep() {

                this.authenticate()
                // this.keep.userID = this.$store.state.user.id
                this.$store.dispatch('newKeep', this.keep)
            },
            getAllKeeps() {
                this.$store.dispatch('getAllKeeps')
            },
            getMyKeeps() {
                this.$store.dispatch('getMyKeeps', this.user.id)
            },
            deleteKeep(keep) {
                console.log(keep)
                this.$store.dispatch('deleteKeep', keep)
            },
            authenticate() {
                this.$store.dispatch('authenticate')
            },
        },
        computed: {
            user() {
                console.log(this.$store.state.user)
                return this.$store.state.user
            },
            vaults() {
                return this.$store.state.activeVaults
            },
            keeps() {
                return this.$store.state.myKeeps
            }
        },
        components: {
            vault
        },
        mounted() {

            console.log(this.$store.state.user.id),
                // this.$store.dispatch('getUserVaults', this.$store.state.user.id),
                // this.$store.dispatch('getMyKeeps', this.user.id)
                this.$store.dispatch('authenticate2')
        }
    }
</script>
<style>
    .brown {
        background-color: burlywood;
    }
    .buttonDiv{
        margin: 1rem;
    }
</style>