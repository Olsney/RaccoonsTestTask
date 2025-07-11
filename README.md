<h1 align="center">🦝 Raccoons Games — Unity Developer Test Task</h1>

<p align="center">
  <a href="https://www.youtube.com/watch?v=TBrEMPnLjdc" target="_blank">
    <img src="https://img.youtube.com/vi/TBrEMPnLjdc/maxresdefault.jpg" width="640" alt="Gameplay Video"/>
  </a>
</p>

<p align="center">
  ▶️ <a href="https://www.youtube.com/watch?v=TBrEMPnLjdc" target="_blank">Watch Gameplay Video</a>
</p>

---

## 📱 Prototype: "2048 3D" — Android Game

This is a physics-based 3D gameplay prototype inspired by the classic puzzle game **2048**, developed as a test task for the Unity Developer position at **Raccoons Games**.

---

## 🧠 What I Implemented

- ✅ **Dependency Injection** using **Zenject**
- ✅ **Service–Component architecture**
- ✅ **State Machine** to manage game flow (Init, Playing, GameOver)
- ✅ **Merge logic** with impulse detection and value validation
- ✅ **DOTween animations** for smooth feedback and polish
- ✅ Modular and scalable codebase for future game features
- ✅ **Win condition**: reach the maximum cube value
- ✅ **Lose condition**: cubes reach the red zone line


---

## 🎯 Task Description

> **Focus Areas:**
- Readable and unified code style  
- Flexible and reliable architecture (with SOLID principles and patterns)  
- Optimized and clean code  
- Gameplay impact (satisfying to play with VFX/animations/physics)  
- Bug-free experience  

> **Gameplay Requirements:**
- A rectangular board with side walls
- Spawn a cube with value:
  - 75% chance — `2`
  - 25% chance — `4`
- The player touches and drags to aim left/right
- On release, the cube is launched forward
- Cubes **merge** when:
  - Their values are equal
  - Collision has **enough impulse**
- Merged value = sum of both cubes (next Power of 2)
- Scoring:
  - `2 + 2 = 4` → +1 point
  - `4 + 4 = 8` → +2 points
  - and so on
- **Game Over** condition is defined by the developer

---

## 🔧 Technologies Used

- Unity 2022+
- Zenject (Extenject) — Dependency Injection
- DOTween — Tweening and animation
- C# — Object-Oriented Programming
- Unity Physics (3D)

---

## 🧑‍💻 Author

**Maksym Kastorskyi**  
[GitHub](https://github.com/Olsney) · [LinkedIn](https://linkedin.com/in/maksym-kastorskyi) · [Telegram](https://t.me/M_Kast)

