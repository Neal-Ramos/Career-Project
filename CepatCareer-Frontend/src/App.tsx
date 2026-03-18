import { BrowserRouter, Route, Routes } from 'react-router-dom'
import LandingPage from './pages/LandingPage'
import ApplyJob from './pages/ApplyJob'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<LandingPage/>}/>
        <Route path='/apply/:jobGuid' element={<ApplyJob/>}/>
      </Routes>
    </BrowserRouter>
  )
}

export default App
