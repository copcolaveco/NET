Public Class pPetriscan
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dPetriscan = CType(o, dPetriscan)
        Dim sql As String = "INSERT INTO petriscan (id, fecha, ficha, muestra,rb) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.FICHA & ",'" & obj.MUESTRA & "', " & obj.RB & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dPetriscan = CType(o, dPetriscan)
        Dim sql As String = "UPDATE petriscan SET fecha ='" & obj.FECHA & "', ficha = " & obj.FICHA & ", muestra='" & obj.MUESTRA & "', rb = " & obj.RB & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dPetriscan = CType(o, dPetriscan)
        Dim sql As String = "DELETE FROM petriscan WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

      

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPetriscan
        Dim obj As dPetriscan = CType(o, dPetriscan)
        Dim c As New dPetriscan
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ficha, muestra, rb FROM petriscan WHERE ficha = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.FICHA = CType(unaFila.Item(2), Long)
                c.MUESTRA = CType(unaFila.Item(3), String)
                c.RB = CType(unaFila.Item(4), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dPetriscan
        Dim obj As dPetriscan = CType(o, dPetriscan)
        Dim c As New dPetriscan
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ficha, muestra, rb FROM petriscan WHERE ficha = " & obj.FICHA & " and muestra='" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.FICHA = CType(unaFila.Item(2), Long)
                c.MUESTRA = CType(unaFila.Item(3), String)
                c.RB = CType(unaFila.Item(4), Integer)

                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, ficha, muestra, rb FROM petriscan order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPetriscan
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.MUESTRA = CType(unaFila.Item(3), String)
                    c.RB = CType(unaFila.Item(4), Integer)

                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fecha, ficha, muestra, rb FROM petriscan where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPetriscan
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.MUESTRA = CType(unaFila.Item(3), String)
                    c.RB = CType(unaFila.Item(4), Integer)

                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fecha, ficha, muestra, rb FROM petriscan where ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPetriscan
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.MUESTRA = CType(unaFila.Item(3), String)
                    c.RB = CType(unaFila.Item(4), Integer)

                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
