import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import Home from './pages/Home';
import WaterDashboard from './pages/WaterDashboard';
import EnergyDashboard from './pages/EnergyDashboard';
import WasteDashboard from './pages/WasteDashboard';
import './App.css'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="water" element={<WaterDashboard />} />
          <Route path="energy" element={<EnergyDashboard />} />
          <Route path="waste" element={<WasteDashboard />} />
        </Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App;
