import { BrowserRouter, Route, Routes } from 'react-router-dom'
import LandingPage from './pages/LandingPage'
import ApplyJob from './pages/ApplyJob'
import AdminLogin from './pages/AdminLogin'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<LandingPage/>}/>
        <Route path='/apply/:jobGuid' element={<ApplyJob/>}/>
        <Route path='/adminLogin' element={<AdminLogin/>}/>
      </Routes>
    </BrowserRouter>
  )
}
export default App
