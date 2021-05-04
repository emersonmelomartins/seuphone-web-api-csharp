import api from "../api";
const route = "users";


export async function UserAuthenticate(authenticateForm) {
  return await api.post(`/${route}/authenticate`, authenticateForm);
}
