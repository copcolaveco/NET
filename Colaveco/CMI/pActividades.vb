Public Class pActividades
    Inherits Conectoras.ConexionMySQL_CMI
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActividades = CType(o, dActividades)
        Dim sql As String = "INSERT INTO actividades (id, iddimension, idobjespecifico, nombre, indicador, meta, aceptable, responsable, plazo, ano, finaliza) VALUES (" & obj.ID & ", " & obj.IDDIMENSION & "," & obj.IDOBJESPECIFICO & ", '" & obj.NOMBRE & "','" & obj.INDICADOR & "', " & obj.META & ", " & obj.ACEPTABLE & ", '" & obj.RESPONSABLE & "', '" & obj.PLAZO & "', " & obj.ANO & ", " & obj.FINALIZA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActividades = CType(o, dActividades)
        Dim sql As String = "UPDATE actividades SET iddimension = " & obj.IDDIMENSION & ",idobjespecifico = " & obj.IDOBJESPECIFICO & ",nombre = '" & obj.NOMBRE & "',indicador = '" & obj.INDICADOR & "', meta = " & obj.META & ",aceptable = " & obj.ACEPTABLE & ",responsable = '" & obj.RESPONSABLE & "',plazo = '" & obj.PLAZO & "',ano = " & obj.ANO & ",finaliza = " & obj.FINALIZA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificaractividad(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActividades = CType(o, dActividades)
        Dim sql As String = "UPDATE actividades SET nombre = '" & obj.NOMBRE & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarindicador(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActividades = CType(o, dActividades)
        Dim sql As String = "UPDATE actividades SET indicador = '" & obj.INDICADOR & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarfinaliza(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActividades = CType(o, dActividades)
        Dim sql As String = "UPDATE actividades SET finaliza = '" & obj.FINALIZA & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarresponsable(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActividades = CType(o, dActividades)
        Dim sql As String = "UPDATE actividades SET responsable = '" & obj.RESPONSABLE & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificaraceptable(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActividades = CType(o, dActividades)
        Dim sql As String = "UPDATE actividades SET aceptable = " & obj.ACEPTABLE & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarmeta(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActividades = CType(o, dActividades)
        Dim sql As String = "UPDATE actividades SET meta = " & obj.META & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActividades = CType(o, dActividades)
        Dim sql As String = "DELETE FROM actividades WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dActividades
        Dim obj As dActividades = CType(o, dActividades)
        Dim a As New dActividades
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, iddimension, idobjespecifico, nombre, ifnull(indicador,''), meta, aceptable, responsable, plazo, ano, finaliza FROM actividades WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.IDDIMENSION = CType(unaFila.Item(1), Long)
                a.IDOBJESPECIFICO = CType(unaFila.Item(2), Long)
                a.NOMBRE = CType(unaFila.Item(3), String)
                a.INDICADOR = CType(unaFila.Item(4), String)
                a.META = CType(unaFila.Item(5), Integer)
                a.ACEPTABLE = CType(unaFila.Item(6), Integer)
                a.RESPONSABLE = CType(unaFila.Item(7), String)
                a.PLAZO = CType(unaFila.Item(8), String)
                a.ANO = CType(unaFila.Item(9), Integer)
                a.FINALIZA = CType(unaFila.Item(10), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, iddimension, idobjespecifico, nombre, ifnull(indicador,''), meta, aceptable, responsable, plazo, ano, finaliza FROM actividades ORDER BY ano DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dActividades
                    a.ID = CType(unaFila.Item(0), Long)
                    a.IDDIMENSION = CType(unaFila.Item(1), Long)
                    a.IDOBJESPECIFICO = CType(unaFila.Item(2), Long)
                    a.NOMBRE = CType(unaFila.Item(3), String)
                    a.INDICADOR = CType(unaFila.Item(4), String)
                    a.META = CType(unaFila.Item(5), Integer)
                    a.ACEPTABLE = CType(unaFila.Item(6), Integer)
                    a.RESPONSABLE = CType(unaFila.Item(7), String)
                    a.PLAZO = CType(unaFila.Item(8), String)
                    a.ANO = CType(unaFila.Item(9), Integer)
                    a.FINALIZA = CType(unaFila.Item(10), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, iddimension, idobjespecifico, nombre, ifnull(indicador,''), meta, aceptable, responsable, plazo, ano, finaliza FROM actividades WHERE ano= " & ano & " ORDER BY iddimension ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dActividades
                    a.ID = CType(unaFila.Item(0), Long)
                    a.IDDIMENSION = CType(unaFila.Item(1), Long)
                    a.IDOBJESPECIFICO = CType(unaFila.Item(2), Long)
                    a.NOMBRE = CType(unaFila.Item(3), String)
                    a.INDICADOR = CType(unaFila.Item(4), String)
                    a.META = CType(unaFila.Item(5), Integer)
                    a.ACEPTABLE = CType(unaFila.Item(6), Integer)
                    a.RESPONSABLE = CType(unaFila.Item(7), String)
                    a.PLAZO = CType(unaFila.Item(8), String)
                    a.ANO = CType(unaFila.Item(9), Integer)
                    a.FINALIZA = CType(unaFila.Item(10), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxobjesp(ByVal idobjesp As Integer) As ArrayList
        Dim sql As String = "SELECT id, iddimension, idobjespecifico, nombre, ifnull(indicador,''), meta, aceptable, responsable, plazo, ano, finaliza FROM actividades WHERE idobjespecifico= " & idobjesp & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dActividades
                    a.ID = CType(unaFila.Item(0), Long)
                    a.IDDIMENSION = CType(unaFila.Item(1), Long)
                    a.IDOBJESPECIFICO = CType(unaFila.Item(2), Long)
                    a.NOMBRE = CType(unaFila.Item(3), String)
                    a.INDICADOR = CType(unaFila.Item(4), String)
                    a.META = CType(unaFila.Item(5), Integer)
                    a.ACEPTABLE = CType(unaFila.Item(6), Integer)
                    a.RESPONSABLE = CType(unaFila.Item(7), String)
                    a.PLAZO = CType(unaFila.Item(8), String)
                    a.ANO = CType(unaFila.Item(9), Integer)
                    a.FINALIZA = CType(unaFila.Item(10), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxdimension(ByVal iddimension As Integer) As ArrayList
        Dim sql As String = "SELECT id, iddimension, idobjespecifico, nombre, ifnull(indicador,''), meta, aceptable, responsable, plazo, ano, finaliza FROM actividades WHERE iddimension= " & iddimension & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a As New dActividades
                    a.ID = CType(unaFila.Item(0), Long)
                    a.IDDIMENSION = CType(unaFila.Item(1), Long)
                    a.IDOBJESPECIFICO = CType(unaFila.Item(2), Long)
                    a.NOMBRE = CType(unaFila.Item(3), String)
                    a.INDICADOR = CType(unaFila.Item(4), String)
                    a.META = CType(unaFila.Item(5), Integer)
                    a.ACEPTABLE = CType(unaFila.Item(6), Integer)
                    a.RESPONSABLE = CType(unaFila.Item(7), String)
                    a.PLAZO = CType(unaFila.Item(8), String)
                    a.ANO = CType(unaFila.Item(9), Integer)
                    a.FINALIZA = CType(unaFila.Item(10), Integer)
                    Lista.Add(a)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultima(ByVal o As Object) As dActividades
        Dim obj As dActividades = CType(o, dActividades)
        Dim a As New dActividades
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, iddimension, idobjespecifico, nombre, ifnull(indicador,''), meta, aceptable, responsable, plazo, ano, finaliza FROM actividades where id = (SELECT MAX(id) FROM actividades)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a.ID = CType(unaFila.Item(0), Long)
                a.IDDIMENSION = CType(unaFila.Item(1), Long)
                a.IDOBJESPECIFICO = CType(unaFila.Item(2), Long)
                a.NOMBRE = CType(unaFila.Item(3), String)
                a.INDICADOR = CType(unaFila.Item(4), String)
                a.META = CType(unaFila.Item(5), Integer)
                a.ACEPTABLE = CType(unaFila.Item(6), Integer)
                a.RESPONSABLE = CType(unaFila.Item(7), String)
                a.PLAZO = CType(unaFila.Item(8), String)
                a.ANO = CType(unaFila.Item(9), Integer)
                a.FINALIZA = CType(unaFila.Item(10), Integer)
                Return a
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
