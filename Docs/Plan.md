# Plan

## Week 1 Goal
- 

### Week 1 Tickets
- [■] GitHub repo 생성 + 초기 커밋
- [■] Unity URP 프로젝트 생성
- [■] .gitignore 적용
- [■] Docs 템플릿 파일 생성(Scope/Wireframes/Plan/Architecture/API/Devlog)
- [□] 이동 및 카메라 구현

## Week 2 Goal
- 완전한 플레이어 이동 공격 인벤토리 구현

### Week 2 Tickets
- [□] 이동 및 카메라 구현
- [□] 공격 구현
- [□] 인벤토리 구현
- [ ] 

## Week 3 Goal

- 탑다운 이동/카메라/조준이 ‘내 손으로’ 완성되고 씬에서 안정적으로 동작한다.

### Week 3 Tickets

- [□] URP 프로젝트 세팅(폴더/레이어/태그) + Main 씬 저장
- [□] Player 이동(WASD) + 중력/충돌(CharacterController)
- [□] 마우스 조준 회전(Raycast to ground)
- [□] 카메라 follow(간단) + Git 커밋/태그(v0.1)

## Week 4 Goal

- 전투 파이프라인(데미지/피격/죽음)과 무기 2슬롯 전환(근접/원거리)이 된다.

### Week 4 Tickets

- [□] HealthComponent + DamageInfo + Death 처리(플레이어/적 공통)
- [□] 근접 공격 1개(Overlap/Range) 구현
- [□]  원거리 투사체 1개(발사/충돌/데미지) 구현
- [□]  무기 슬롯 전환(1/2) + 최소 피드백(텍스트/아이콘)

## Week 5 Goal

- 적 1종이 스폰되고 추적/공격하며 게임 플레이가 성립한다.

## Week 5 Tickets

- [□] Enemy AI(FSM: Idle/Patrol/Chase/Attack)
- [□] NavMesh 적용 + 추적 이동 안정화
- [□] 스폰 시스템(간단 규칙: 시간/구역) + 리스폰
- [□] 적 체력바(월드 UI) + 사망 처리 확인

## Week 6 Goal

- 루팅과 인벤토리로 “파밍 루프”가 시작된다.

### Week 6 Tickets

- [□] ItemData(SO) + ItemStack 구조 설계
- [□] 상자/컨테이너 루팅(E 상호작용)
- [□] 인벤토리(슬롯/스택/추가/제거) + 드랍
- [□] 인벤 UI 연결(열기/닫기, 아이템 정보 표시)

## Week 7 Goal

- 크래프팅(레시피 3~5개)로 생존/탈출에 필요한 아이템을 만든다.

### Week 7 Tickets

- [□] RecipeData(SO) + CraftService(CanCraft/TryCraft)
- [□] 레시피 3~5개 구현(예: 붕대/창/탄약/열쇠 관련)
- [□] Craft UI(레시피 목록/재료 부족 표시)
- [□] 밸런스 1차(드랍/재료/제작 비용 조정)

## Week 8 Goal

- “탈출 루프(정보→헬기→열쇠→탈출)”가 완성되어 클리어가 된다.

### Week 8 Tickets

- [□] 정보 아이템 획득 → 헬기 활성/생성(고정 위치) 흐름 구현
- [□] 열쇠 획득(고정 위치/주변 탐색) + 진행도 UI(체크/카운트)
- [□] 탈출 트리거 + 클리어 Result 화면
- [□] 실패(사망) Result 화면 + 재시작/타이틀

## Week 9 Goal

- 풀 세이브(너가 정의한 범위)로 저장/불러오기가 된다.

### Week 9 Tickets

- [□] SaveData 구조 설계(플레이어 위치/아이템/진행/스탯)
- [□] Save(세이브포인트 or 메뉴) + Load(Continue) 구현
- [□] 로드 후 상태 복원(인벤/진행/스탯/위치) 검증
- [□] 버전 필드 추가 + 데이터 깨짐 대비(기본값 처리)

## Week 10 Goal

- UI/씬 흐름이 안정화되고 플레이가 끊기지 않는다(버그픽스/리팩토링).

### Week 10 Tickets

- [□] Title/Settings(최소) + Ingame Pause UI
- [□] 입력/상호작용 UX 정리(E, I, Esc 등)
- [□] 성능/GC 체크(불필요 Update 제거, 간단 풀링 1개)
- [□] 핵심 버그 리스트 10개 잡고 해결(우선순위)