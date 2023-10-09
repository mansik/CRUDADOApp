# DB 프로젝트 생성 및 게시 방법

* SQL Server DataBase project 추가 
	* 프로젝트명 UserDB
	* dbo 폴더 추가
		* Tables 폴더 추가
			* `Table` 추가
			* Student
	* StoredProcedures 폴더 추가
		* `저장 프로시저` 추가
		* spUser_GetAll
		* spUser_GetById
		* spUser_Insert
		* spUser_Update
		* spUser_Delete
	* DataBase project에서 `스크립트` 추가
		* `배포 후 스크립트` 추가 => Script.PostDEployment.sql
		* 테이블에 삽입할 쿼리 작성
		```SQL
		if not exists (select 1 from Student)
		begin
			insert into Student([Name], Reg, Class, Section)
			values ('Mary', '15-FB-120', 'A', 'section 1'),
			('Joy', '15-FB-121', 'A', 'section 2'),
			('Tom', '15-FB-122', 'B', 'section 1'),
			('Sue', '23-FB-123', 'B', 'section 2'),
			('Amily', '23-FB-124', 'B', 'section 3');
		end
		```
	* DataBase project에서 `게시` 선택
		* 편집에서 DB 인스턴스 선택
		* Database 이름 CRUDADO
		* 스크립트 이름 UserDB.sql => 자동으로 생성됨
		* Profile로 저장
	* 그러면 프로젝트에 UserDB.publish.xml파일로 존재
	* .GitIgnore를 통해 저장소에 빠지므로 마우스 우측클릭-> git ->`소스 제어에 무시된 파일 추가`를 통해 추가한다.
	* UserDB.publish.xml을 더블클릭하면 게시화면을 호출할 수 있으며,
	* 게시 한다.
	* Database가 제대로 생성 되었는지 확인한다.