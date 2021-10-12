Public Class pBacteriologia
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBacteriologia = CType(o, dBacteriologia)
        Dim sql As String = "INSERT INTO bacteriologia (id, ficha, fechasolicitud, fechaproceso, idmuestra, rc, rb, coliformes, termoduricos, estreptococoag, estreptococodys, estreptococoub, estreptococospp, estafilococoau, estapylocococoagneg, psicrotrofos, corynebacterium, otros, observaciones, operador,  marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.FECHASOLICITUD & "','" & obj.FECHAPROCESO & "','" & obj.IDMUESTRA & "', '" & obj.RC & "', '" & obj.RB & "','" & obj.COLIFORMES & "','" & obj.TERMODURICOS & "','" & obj.ESTREPTOCOCOAG & "','" & obj.ESTREPTOCOCODYS & "','" & obj.ESTREPTOCOCOUB & "','" & obj.ESTREPTOCOCOSPP & "','" & obj.ESTAFILOCOCOAU & "','" & obj.ESTAPYLOCOCOCOAGNEG & "','" & obj.PSICROTROFOS & "','" & obj.CORYNEBACTERIUM & "','" & obj.OTROS & "','" & obj.OBSERVACIONES & "', " & obj.OPERADOR & ", " & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'bacteriologia', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBacteriologia = CType(o, dBacteriologia)
        Dim sql As String = "UPDATE bacteriologia SET ficha = " & obj.FICHA & ",  fechasolicitud ='" & obj.FECHASOLICITUD & "',fechaproceso ='" & obj.FECHAPROCESO & "', idmuestra ='" & obj.IDMUESTRA & "',rc = '" & obj.RC & "', rb = '" & obj.RB & "',coliformes = '" & obj.COLIFORMES & "',termoduricos = '" & obj.TERMODURICOS & "',estreptococoag = '" & obj.ESTREPTOCOCOAG & "',estreptococodys = '" & obj.ESTREPTOCOCODYS & "',estreptococoub = '" & obj.ESTREPTOCOCOUB & "',estreptococospp = '" & obj.ESTREPTOCOCOSPP & "',estafilococoau = '" & obj.ESTAFILOCOCOAU & "',estapylocococoagneg = '" & obj.ESTAPYLOCOCOCOAGNEG & "',psicrotrofos = '" & obj.PSICROTROFOS & "',corynebacterium = '" & obj.CORYNEBACTERIUM & "', otros = '" & obj.OTROS & "',observaciones = '" & obj.OBSERVACIONES & "',operador=" & obj.OPERADOR & ", marca=" & obj.MARCA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'bacteriologia', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBacteriologia = CType(o, dBacteriologia)
        Dim sql As String = "UPDATE bacteriologia SET fechaproceso ='" & obj.FECHAPROCESO & "', marca=" & obj.MARCA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'bacteriologia', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBacteriologia = CType(o, dBacteriologia)
        Dim sql As String = "DELETE FROM bacteriologia WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'bacteriologia', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dBacteriologia
        Dim obj As dBacteriologia = CType(o, dBacteriologia)
        Dim b As New dBacteriologia
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, rc, rb, coliformes, termoduricos, estreptococoag, estreptococodys, estreptococoub, estreptococospp, estafilococoau, estapylocococoagneg, psicrotrofos, corynebacterium, otros, observaciones, operador,  marca FROM bacteriologia WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                b.ID = CType(unaFila.Item(0), Long)
                b.FICHA = CType(unaFila.Item(1), Long)
                b.FECHASOLICITUD = CType(unaFila.Item(2), String)
                b.FECHAPROCESO = CType(unaFila.Item(3), String)
                b.IDMUESTRA = CType(unaFila.Item(4), String)
                b.RC = CType(unaFila.Item(5), String)
                b.RB = CType(unaFila.Item(6), String)
                b.COLIFORMES = CType(unaFila.Item(7), String)
                b.TERMODURICOS = CType(unaFila.Item(8), String)
                b.ESTREPTOCOCOAG = CType(unaFila.Item(9), String)
                b.ESTREPTOCOCODYS = CType(unaFila.Item(10), String)
                b.ESTREPTOCOCOUB = CType(unaFila.Item(11), String)
                b.ESTREPTOCOCOSPP = CType(unaFila.Item(12), String)
                b.ESTAFILOCOCOAU = CType(unaFila.Item(13), String)
                b.ESTAPYLOCOCOCOAGNEG = CType(unaFila.Item(14), String)
                b.PSICROTROFOS = CType(unaFila.Item(15), String)
                b.CORYNEBACTERIUM = CType(unaFila.Item(16), String)
                b.OTROS = CType(unaFila.Item(17), String)
                b.OBSERVACIONES = CType(unaFila.Item(18), String)
                b.OPERADOR = CType(unaFila.Item(19), Integer)
                b.MARCA = CType(unaFila.Item(20), Integer)
                Return b
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, rc, rb, coliformes, termoduricos, estreptococoag, estreptococodys, estreptococoub, estreptococospp, estafilococoau, estapylocococoagneg, psicrotrofos, corynebacterium, otros, observaciones, operador,  marca FROM bacteriologia WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim b As New dBacteriologia
                    b.ID = CType(unaFila.Item(0), Long)
                    b.FICHA = CType(unaFila.Item(1), Long)
                    b.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    b.FECHAPROCESO = CType(unaFila.Item(3), String)
                    b.IDMUESTRA = CType(unaFila.Item(4), String)
                    b.RC = CType(unaFila.Item(5), String)
                    b.RB = CType(unaFila.Item(6), String)
                    b.COLIFORMES = CType(unaFila.Item(7), String)
                    b.TERMODURICOS = CType(unaFila.Item(8), String)
                    b.ESTREPTOCOCOAG = CType(unaFila.Item(9), String)
                    b.ESTREPTOCOCODYS = CType(unaFila.Item(10), String)
                    b.ESTREPTOCOCOUB = CType(unaFila.Item(11), String)
                    b.ESTREPTOCOCOSPP = CType(unaFila.Item(12), String)
                    b.ESTAFILOCOCOAU = CType(unaFila.Item(13), String)
                    b.ESTAPYLOCOCOCOAGNEG = CType(unaFila.Item(14), String)
                    b.PSICROTROFOS = CType(unaFila.Item(15), String)
                    b.CORYNEBACTERIUM = CType(unaFila.Item(16), String)
                    b.OTROS = CType(unaFila.Item(17), String)
                    b.OBSERVACIONES = CType(unaFila.Item(18), String)
                    b.OPERADOR = CType(unaFila.Item(19), Integer)
                    b.MARCA = CType(unaFila.Item(20), Integer)
                    Lista.Add(b)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM bacteriologia WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim b As New dBacteriologia
                    b.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(b)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, rc, rb, coliformes, termoduricos, estreptococoag, estreptococodys, estreptococoub, estreptococospp, estafilococoau, estapylocococoagneg, psicrotrofos, corynebacterium, otros, observaciones, operador,  marca  FROM bacteriologia where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim b As New dBacteriologia
                    b.ID = CType(unaFila.Item(0), Long)
                    b.FICHA = CType(unaFila.Item(1), Long)
                    b.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    b.FECHAPROCESO = CType(unaFila.Item(3), String)
                    b.IDMUESTRA = CType(unaFila.Item(4), String)
                    b.RC = CType(unaFila.Item(5), String)
                    b.RB = CType(unaFila.Item(6), String)
                    b.COLIFORMES = CType(unaFila.Item(7), String)
                    b.TERMODURICOS = CType(unaFila.Item(8), String)
                    b.ESTREPTOCOCOAG = CType(unaFila.Item(9), String)
                    b.ESTREPTOCOCODYS = CType(unaFila.Item(10), String)
                    b.ESTREPTOCOCOUB = CType(unaFila.Item(11), String)
                    b.ESTREPTOCOCOSPP = CType(unaFila.Item(12), String)
                    b.ESTAFILOCOCOAU = CType(unaFila.Item(13), String)
                    b.ESTAPYLOCOCOCOAGNEG = CType(unaFila.Item(14), String)
                    b.PSICROTROFOS = CType(unaFila.Item(15), String)
                    b.CORYNEBACTERIUM = CType(unaFila.Item(16), String)
                    b.OTROS = CType(unaFila.Item(17), String)
                    b.OBSERVACIONES = CType(unaFila.Item(18), String)
                    b.OPERADOR = CType(unaFila.Item(19), Integer)
                    b.MARCA = CType(unaFila.Item(20), Integer)
                    Lista.Add(b)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, rc, rb, coliformes, termoduricos, estreptococoag, estreptococodys, estreptococoub, estreptococospp, estafilococoau, estapylocococoagneg, psicrotrofos, corynebacterium, otros, observaciones, operador,  marca FROM bacteriologia where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim b As New dBacteriologia
                    b.ID = CType(unaFila.Item(0), Long)
                    b.FICHA = CType(unaFila.Item(1), Long)
                    b.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    b.FECHAPROCESO = CType(unaFila.Item(3), String)
                    b.IDMUESTRA = CType(unaFila.Item(4), String)
                    b.RC = CType(unaFila.Item(5), String)
                    b.RB = CType(unaFila.Item(6), String)
                    b.COLIFORMES = CType(unaFila.Item(7), String)
                    b.TERMODURICOS = CType(unaFila.Item(8), String)
                    b.ESTREPTOCOCOAG = CType(unaFila.Item(9), String)
                    b.ESTREPTOCOCODYS = CType(unaFila.Item(10), String)
                    b.ESTREPTOCOCOUB = CType(unaFila.Item(11), String)
                    b.ESTREPTOCOCOSPP = CType(unaFila.Item(12), String)
                    b.ESTAFILOCOCOAU = CType(unaFila.Item(13), String)
                    b.ESTAPYLOCOCOCOAGNEG = CType(unaFila.Item(14), String)
                    b.PSICROTROFOS = CType(unaFila.Item(15), String)
                    b.CORYNEBACTERIUM = CType(unaFila.Item(16), String)
                    b.OTROS = CType(unaFila.Item(17), String)
                    b.OBSERVACIONES = CType(unaFila.Item(18), String)
                    b.OPERADOR = CType(unaFila.Item(19), Integer)
                    b.MARCA = CType(unaFila.Item(20), Integer)
                    Lista.Add(b)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, rc, rb, coliformes, termoduricos, estreptococoag, estreptococodys, estreptococoub, estreptococospp, estafilococoau, estapylocococoagneg, psicrotrofos, corynebacterium, otros, observaciones, operador,  marca  FROM bacteriologia where marca = 0 and ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim b As New dBacteriologia
                    b.ID = CType(unaFila.Item(0), Long)
                    b.FICHA = CType(unaFila.Item(1), Long)
                    b.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    b.FECHAPROCESO = CType(unaFila.Item(3), String)
                    b.IDMUESTRA = CType(unaFila.Item(4), String)
                    b.RC = CType(unaFila.Item(5), String)
                    b.RB = CType(unaFila.Item(6), String)
                    b.COLIFORMES = CType(unaFila.Item(7), String)
                    b.TERMODURICOS = CType(unaFila.Item(8), String)
                    b.ESTREPTOCOCOAG = CType(unaFila.Item(9), String)
                    b.ESTREPTOCOCODYS = CType(unaFila.Item(10), String)
                    b.ESTREPTOCOCOUB = CType(unaFila.Item(11), String)
                    b.ESTREPTOCOCOSPP = CType(unaFila.Item(12), String)
                    b.ESTAFILOCOCOAU = CType(unaFila.Item(13), String)
                    b.ESTAPYLOCOCOCOAGNEG = CType(unaFila.Item(14), String)
                    b.PSICROTROFOS = CType(unaFila.Item(15), String)
                    b.CORYNEBACTERIUM = CType(unaFila.Item(16), String)
                    b.OTROS = CType(unaFila.Item(17), String)
                    b.OBSERVACIONES = CType(unaFila.Item(18), String)
                    b.OPERADOR = CType(unaFila.Item(19), Integer)
                    b.MARCA = CType(unaFila.Item(20), Integer)
                    Lista.Add(b)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, rc, rb, coliformes, termoduricos, estreptococoag, estreptococodys, estreptococoub, estreptococospp, estafilococoau, estapylocococoagneg, psicrotrofos, corynebacterium, otros, observaciones, operador,  marca  FROM bacteriologia where marca = 1 and ficha = " & texto & " Order BY id ASC")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim b As New dBacteriologia
                    b.ID = CType(unaFila.Item(0), Long)
                    b.FICHA = CType(unaFila.Item(1), Long)
                    b.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    b.FECHAPROCESO = CType(unaFila.Item(3), String)
                    b.IDMUESTRA = CType(unaFila.Item(4), String)
                    b.RC = CType(unaFila.Item(5), String)
                    b.RB = CType(unaFila.Item(6), String)
                    b.COLIFORMES = CType(unaFila.Item(7), String)
                    b.TERMODURICOS = CType(unaFila.Item(8), String)
                    b.ESTREPTOCOCOAG = CType(unaFila.Item(9), String)
                    b.ESTREPTOCOCODYS = CType(unaFila.Item(10), String)
                    b.ESTREPTOCOCOUB = CType(unaFila.Item(11), String)
                    b.ESTREPTOCOCOSPP = CType(unaFila.Item(12), String)
                    b.ESTAFILOCOCOAU = CType(unaFila.Item(13), String)
                    b.ESTAPYLOCOCOCOAGNEG = CType(unaFila.Item(14), String)
                    b.PSICROTROFOS = CType(unaFila.Item(15), String)
                    b.CORYNEBACTERIUM = CType(unaFila.Item(16), String)
                    b.OTROS = CType(unaFila.Item(17), String)
                    b.OBSERVACIONES = CType(unaFila.Item(18), String)
                    b.OPERADOR = CType(unaFila.Item(19), Integer)
                    b.MARCA = CType(unaFila.Item(20), Integer)
                    Lista.Add(b)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fechasolicitud, fechaproceso, idmuestra, rc, rb, coliformes, termoduricos, estreptococoag, estreptococodys, estreptococoub, estreptococospp, estafilococoau, estapylocococoagneg, psicrotrofos, corynebacterium, otros, observaciones, operador,  marca  FROM bacteriologia where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim b As New dBacteriologia
                    b.ID = CType(unaFila.Item(0), Long)
                    b.FICHA = CType(unaFila.Item(1), Long)
                    b.FECHASOLICITUD = CType(unaFila.Item(2), String)
                    b.FECHAPROCESO = CType(unaFila.Item(3), String)
                    b.IDMUESTRA = CType(unaFila.Item(4), String)
                    b.RC = CType(unaFila.Item(5), String)
                    b.RB = CType(unaFila.Item(6), String)
                    b.COLIFORMES = CType(unaFila.Item(7), String)
                    b.TERMODURICOS = CType(unaFila.Item(8), String)
                    b.ESTREPTOCOCOAG = CType(unaFila.Item(9), String)
                    b.ESTREPTOCOCODYS = CType(unaFila.Item(10), String)
                    b.ESTREPTOCOCOUB = CType(unaFila.Item(11), String)
                    b.ESTREPTOCOCOSPP = CType(unaFila.Item(12), String)
                    b.ESTAFILOCOCOAU = CType(unaFila.Item(13), String)
                    b.ESTAPYLOCOCOCOAGNEG = CType(unaFila.Item(14), String)
                    b.PSICROTROFOS = CType(unaFila.Item(15), String)
                    b.CORYNEBACTERIUM = CType(unaFila.Item(16), String)
                    b.OTROS = CType(unaFila.Item(17), String)
                    b.OBSERVACIONES = CType(unaFila.Item(18), String)
                    b.OPERADOR = CType(unaFila.Item(19), Integer)
                    b.MARCA = CType(unaFila.Item(20), Integer)
                    Lista.Add(b)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
