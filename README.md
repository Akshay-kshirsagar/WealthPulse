# 🚀 AI-Assisted Quant Trading System

A production-grade **systematic swing trading platform** built using .NET, microservices architecture, and AI-assisted analytics.

---

## 📌 Overview

This project implements a **rule-based trading system** for NIFTY 50 stocks with:

* 📊 Technical + Fundamental filtering
* ⚙️ Automated signal generation
* 🧪 Backtesting engine
* 📉 Risk management system
* 🤖 AI-powered trade analysis

---

## 🧠 Strategy

### Market

* NIFTY 50 stocks

### Trading Style

* Swing Trading (End-of-Day)

### Entry Logic

* EMA 20 > EMA 50
* Breakout above 5-day high
* Volume ≥ 1.5× average
* RSI between 50–70
* Market trend confirmation

### Entry Modes

* Breakout
* Pullback

### Exit Logic

* Stop Loss: EMA20 / swing low
* 1R → Breakeven
* 1.5R → Partial profit
* Trailing stop (EMA / previous low)
* Time exit (5–7 days)

---

## 💰 Risk Management

* Risk per trade: 1%
* Max trades: 5
* Max drawdown: 5% (kill switch)

---

## 🏗️ Architecture

* Microservices-based design
* Event-driven workflow
* Clean architecture (SOLID principles)

### Services:

* MarketDataService
* IndicatorService
* SignalEngineService
* BacktestingService
* NotificationService

---

## 🔄 System Workflow

1. Fetch market data
2. Calculate indicators
3. Generate signals
4. Backtest strategy
5. Send alerts
6. AI analyzes performance

---

## 🗄️ Database Design

Core tables:

* Stocks
* MarketData
* Indicators
* Signals
* Trades
* PerformanceMetrics

---

## 📡 API Endpoints

```
GET    /api/signals
POST   /api/signals/generate

GET    /api/trades
POST   /api/trades/execute

POST   /api/backtest/run
GET    /api/backtest/results
```

---

## 🤖 AI Integration

Uses AI for:

* Trade journaling analysis
* Pattern detection
* Strategy improvement

Compatible with:

* OpenAI (ChatGPT)
* Claude

---

## 🛠️ Tech Stack

### Backend

* .NET Core (6/7/8)
* ASP.NET Core Web API
* Entity Framework Core

### Frontend

* Angular 17+
* RxJS

### Database

* SQL Server

### Cloud

* AWS (SQS, EC2, CloudWatch)
* Azure (App Service, Functions)

### DevOps

* Docker
* Jenkins CI/CD
* GitHub Actions

---

## 🧪 Backtesting Metrics

* Win Rate
* Drawdown
* Expectancy
* R-Multiple
* Equity Curve

---

## 📩 Notifications

* Telegram Alerts
* Email Alerts

---

## 🚀 Getting Started

### 1. Clone Repo

```
git clone https://github.com/your-username/ai-quant-trading-system.git
```

### 2. Setup Database

```
dotnet ef database update
```

### 3. Run Services

```
dotnet run
```

---

## 📈 Roadmap

* [ ] Options trading module
* [ ] Real-time execution
* [ ] AI auto-optimization
* [ ] Advanced analytics dashboard

---

## ⚠️ Disclaimer

This project is for educational and research purposes only.
Trading involves risk. Past performance does not guarantee future results.

---

## 👨‍💻 Author

Built as a **quantitative trading + software engineering project**.

---

## ⭐ If you like this project

Give it a star ⭐ and follow for updates!
