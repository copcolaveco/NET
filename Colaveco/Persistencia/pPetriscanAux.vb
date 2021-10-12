Public Class pPetriscanAux
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dPetriscanAux = CType(o, dPetriscanAux)
        Dim sql As String = "INSERT INTO petriscan_aux (id, fecha, ficha, muestra,dilucion, rb) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.FICHA & ",'" & obj.MUESTRA & "', " & obj.DILUCION & ", " & obj.RB & ")"

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dPetriscanAux = CType(o, dPetriscanAux)
        Dim sql As String = "UPDATE petriscan_aux SET fecha ='" & obj.FECHA & "', ficha = " & obj.FICHA & ", muestra='" & obj.MUESTRA & "', dilucion = " & obj.DILUCION & ", rb = " & obj.RB & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dPetriscanAux = CType(o, dPetriscanAux)
        Dim sql As String = "DELETE FROM petriscan_aux WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPetriscanAux
        Dim obj As dPetriscanAux = CType(o, dPetriscanAux)
        Dim c As New dPetriscanAux
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ficha, muestra,dilucion, rb FROM petriscan_aux WHERE ficha = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.FICHA = CType(unaFila.Item(2), Long)
                c.MUESTRA = CType(unaFila.Item(3), String)
                c.DILUCION = CType(unaFila.Item(4), Integer)
                c.RB = CType(unaFila.Item(5), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dPetriscanAux
        Dim obj As dPetriscanAux = CType(o, dPetriscanAux)
        Dim c As New dPetriscanAux
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ficha, muestra,dilucion, rb FROM petriscan_aux WHERE ficha = " & obj.FICHA & " and muestra='" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.FICHA = CType(unaFila.Item(2), Long)
                c.MUESTRA = CType(unaFila.Item(3), String)
                c.DILUCION = CType(unaFila.Item(4), Integer)
                c.RB = CType(unaFila.Item(5), Integer)

                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, ficha, muestra, dilucion, rb FROM petriscan_aux order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPetriscanAux
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.MUESTRA = CType(unaFila.Item(3), String)
                    c.DILUCION = CType(unaFila.Item(4), Integer)
                    c.RB = CType(unaFila.Item(5), Integer)

                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fecha, ficha, muestra, dilucion, rb FROM petriscan_aux where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPetriscanAux
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.MUESTRA = CType(unaFila.Item(3), String)
                    c.DILUCION = CType(unaFila.Item(4), Integer)
                    c.RB = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fecha, ficha, muestra, dilucion, rb FROM petriscan_aux where ficha = " & texto & " ORDER BY dilucion ASC")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPetriscanAux
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.MUESTRA = CType(unaFila.Item(3), String)
                    c.DILUCION = CType(unaFila.Item(4), Integer)
                    c.RB = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listardistintasmuestras(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT DISTINCT (muestra), ficha FROM petriscan_aux where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPetriscanAux
                    c.MUESTRA = CType(unaFila.Item(0), String)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listardistintasfichas() As ArrayList
        Dim sql As String = ("SELECT DISTINCT (ficha) FROM petriscan_aux")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPetriscanAux
                    c.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfichaxmuestra(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = ("SELECT id, fecha, ficha, muestra, dilucion, rb FROM petriscan_aux where ficha = " & ficha & " AND muestra = '" & muestra & "' ORDER BY dilucion ASC")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPetriscanAux
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.MUESTRA = CType(unaFila.Item(3), String)
                    c.DILUCION = CType(unaFila.Item(4), Integer)
                    c.RB = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
