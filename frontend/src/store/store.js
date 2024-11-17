import vue from "vue"
import Vuex from "vuex"

vue.use(Vuex)

const store=new Vuex.Store({
    state(){
        return{
            loading:false,
            error:null,
            user:JSON.parse(localStorage.getItem('user')) || null
        }
    },
    mutations:{
        LOGIN_START(state){
            state.loading=true,
            state.error=false,
            state.user=null
        },
        LOGIN_SUCCESS(state,user){
            state.loading=false,
            state.error=false,
            state.user=user || null,
            localStorage.setItem('user',JSON.stringify(user))
        },
        LOGIN_FAILURE(state,error){
            state.loading=false,
            state.user=null,
            state.error=error
        },
        LOGOUT(state){
            state.loading=false,
            state.user=null,
            state.error=null,
            localStorage.removeItem('user');
        }
    },
    getters:{
        currentUser: state=>{
            return state.user
        },
        isAdmin(state) {
            return state.user.role === 'Admin';
          },
    }
})
export default store